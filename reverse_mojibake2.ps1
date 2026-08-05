$ErrorActionPreference = "Stop"

$filesToFix = @(
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\BaseForms\BaseListForm.Designer.cs",
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateEditForm.Designer.cs",
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateListForm.Designer.cs"
)

$utf8 = [System.Text.Encoding]::UTF8
$utf8WithBom = New-Object System.Text.UTF8Encoding($true)
$win1254 = [System.Text.Encoding]::GetEncoding(1254)

$c3 = [char]0x00C3
$c5 = [char]0x00C5
$c4 = [char]0x00C4

foreach ($file in $filesToFix) {
    if (Test-Path $file) {
        $content = [System.IO.File]::ReadAllText($file, $utf8)
        
        if ($content.Contains($c3) -or $content.Contains($c5) -or $content.Contains($c4)) {
            
            $ansiBytes = $win1254.GetBytes($content)
            $fixedContent = $utf8.GetString($ansiBytes)
            
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
