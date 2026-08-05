$ErrorActionPreference = "Stop"

$filesToFix = @(
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\BaseForms\BaseListForm.Designer.cs",
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateEditForm.Designer.cs",
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateListForm.Designer.cs"
)

$utf8 = [System.Text.Encoding]::UTF8
$utf8WithBom = New-Object System.Text.UTF8Encoding($true)
$win1254 = [System.Text.Encoding]::GetEncoding(1254)

foreach ($file in $filesToFix) {
    if (Test-Path $file) {
        # Read the double-encoded UTF-8 file
        $content = [System.IO.File]::ReadAllText($file, $utf8)
        
        # Check if it has mojibake (e.g., 'Ã' character which is typical for UTF8 interpreted as ANSI)
        if ($content.Contains("Ã") -or $content.Contains("Å") -or $content.Contains("Ä")) {
            
            # Convert the mojibake string back to bytes using Windows-1254
            $ansiBytes = $win1254.GetBytes($content)
            
            # Decode the bytes back to a string using UTF-8
            $fixedContent = $utf8.GetString($ansiBytes)
            
            # Write back with proper UTF-8 BOM
            [System.IO.File]::WriteAllText($file, $fixedContent, $utf8WithBom)
            Write-Host "Reversed Mojibake and saved with UTF-8 BOM: $file"
        } else {
            Write-Host "No Mojibake found in: $file"
        }
    } else {
        Write-Warning "File not found: $file"
    }
}
Write-Host "Double Encoding Fix Completed."
