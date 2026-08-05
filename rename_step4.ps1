$ErrorActionPreference = "Stop"
$dir = "c:\Users\User\source\repos\ThermaCore"

$extensions = @("*.cs", "*.json", "*.resx", "*.Designer.cs")

Write-Host "Finding files for remaining thermacore replaces..."
$files = Get-ChildItem -Path $dir -Include $extensions -Recurse -File | Where-Object {
    $_.FullName -notmatch "\\(bin|obj|\.git|\.vs|packages)\\"
}

$count = 0
foreach ($file in $files) {
    try {
        $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
        if ($content) {
            $changed = $false
            
            if ($content -match "WinBeyazEsyaMaster!") {
                $content = $content.Replace("WinBeyazEsyaMaster!", "winbeyazesyayonetim!")
                $changed = $true
            }
            if ($content -match "(?i)thermacore!") {
                $content = [regex]::Replace($content, "(?i)thermacore!", "winbeyazesyayonetim!")
                $changed = $true
            }
            if ($content -match "THERMACORE") {
                $content = $content.Replace("THERMACORE", "WINBEYAZESYA")
                $changed = $true
            }
            if ($content -match "Thermacore") {
                $content = $content.Replace("Thermacore", "Winbeyazesya")
                $changed = $true
            }
            if ($content -match "thermacore") {
                $content = $content.Replace("thermacore", "winbeyazesya")
                $changed = $true
            }
            
            if ($changed) {
                Set-Content -Path $file.FullName -Value $content -Encoding UTF8
                $count++
            }
        }
    }
    catch {
        Write-Warning "Could not process file: $($file.FullName) - $($_.Exception.Message)"
    }
}

Write-Host "Successfully updated $count files."
