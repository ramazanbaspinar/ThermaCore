$ErrorActionPreference = "Stop"
$dir = "c:\Users\User\source\repos\ThermaCore"

$extensions = @("*.cs", "*.json", "*.resx")

Write-Host "Finding files..."
$files = Get-ChildItem -Path $dir -Include $extensions -Recurse -File | Where-Object {
    $_.FullName -notmatch "\\(bin|obj|\.git|\.vs|packages)\\"
}

Write-Host "Found $($files.Count) files to process."

$count = 0
foreach ($file in $files) {
    try {
        $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
        if ($content) {
            $changed = $false
            
            if ($content.Contains("ThermaCoreMasterDB")) {
                $content = $content.Replace("ThermaCoreMasterDB", "WinBeyazEsyaYonetimDB")
                $changed = $true
            }
            
            if ($content.Contains("ThermaCore")) {
                $content = $content.Replace("ThermaCore", "WinBeyazEsya")
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
