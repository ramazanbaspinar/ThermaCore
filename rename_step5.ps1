$ErrorActionPreference = "Stop"
$dir = "c:\Users\User\source\repos\ThermaCore"

$extensions = @("*.cs", "*.resx")

$files = Get-ChildItem -Path $dir -Include $extensions -Recurse -File | Where-Object {
    $_.FullName -notmatch "\\(bin|obj|\.git|\.vs|packages)\\"
}

$count = 0
foreach ($file in $files) {
    try {
        $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
        if ($content) {
            $changed = $false
            
            $replacements = @{
                'txtKod.Text.ToLower() == "admin" || ' = ''
                'userCode.ToLower() == "admin" || ' = ''
                'user.Code.ToLower() == "admin" || ' = ''
                'username.ToLower() == "admin" || ' = ''
                'ADMIN/WINBEYAZESYA' = 'winbeyazesya'
                'ADMIN_ROLE' = 'WINBEYAZESYA_ROLE'
                'admin@winbeyazesya.com' = 'info@winbeyazesya.com'
                'Admin veya winbeyazesya' = 'winbeyazesya'
                'Admin ise veya winbeyazesya ise' = 'winbeyazesya ise'
                'Admin ise tüm aktif şirketleri listele' = 'SuperAdmin ise tüm aktif şirketleri listele'
            }

            foreach ($key in $replacements.Keys) {
                if ($content.Contains($key)) {
                    $content = $content.Replace($key, $replacements[$key])
                    $changed = $true
                }
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
