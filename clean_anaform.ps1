$roots = @('Sac', 'Tel', 'Izgara', 'Tepsi', 'Rezistans', 'Kablo', 'Motor', 'Fan', 'AnahtarRotary', 'Termostat', 'Timer', 'Lamba', 'PleytIsitici', 'GazMuslugu', 'Valf', 'BekGrubu', 'Enjektor', 'Termokupl', 'Cakmak', 'AteslemeTrafosu', 'GazBorusu', 'Rakor', 'PlastikParca', 'Kulp', 'Dugme', 'Cam', 'Boya', 'Emaye', 'Izolasyon', 'Conta', 'Vida', 'Mentese', 'Kilit', 'BaglantiElemani', 'AmbalajMalzemesi', 'Matbaa', 'Etiket', 'KaliteStandart', 'YuzeyTipi', 'CamTipi', 'Renk', 'Pleyt')

$csPath = 'c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\GenelForms\AnaForm.cs'
$designerPath = 'c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\GenelForms\AnaForm.Designer.cs'

# Process AnaForm.cs
$csContent = Get-Content $csPath -Raw
foreach ($root in $roots) {
    $pattern = '(?s)[ \t]*if \(mi' + $root + '(Tanimlari|Maliyetleri) != null\)\s*\{\s*mi' + $root + '(Tanimlari|Maliyetleri)\.Tag.*?XtraMessageBox\.Show\([^;]+;\s*\}\s*\};\s*\}'
    $csContent = [System.Text.RegularExpressions.Regex]::Replace($csContent, $pattern, '')
    
    $pattern2 = '(?s)[ \t]*if \(mi' + $root + '(Tanimlari|Maliyetleri) != null\)\s*\{\s*mi' + $root + '(Tanimlari|Maliyetleri)\.Tag.*?MessageBox\.Show\([^;]+;\s*\}\s*\};\s*\}'
    $csContent = [System.Text.RegularExpressions.Regex]::Replace($csContent, $pattern2, '')
}
$csContent | Set-Content $csPath

# Process AnaForm.Designer.cs
$designerContent = Get-Content $designerPath
$newDesignerContent = @()
foreach ($line in $designerContent) {
    $shouldKeep = $true
    foreach ($root in $roots) {
        if ($line -match "mi$root(Tanimlari|Maliyetleri)") {
            if ($line -match "AddRange") {
                $line = [System.Text.RegularExpressions.Regex]::Replace($line, "mi$root(Tanimlari|Maliyetleri)[, ]*", '')
            } else {
                $shouldKeep = $false
                break
            }
        }
    }
    
    if ($shouldKeep) {
        # Fix empty arrays in AddRange if any
        $line = $line -replace 'new System\.Windows\.Forms\.ToolStripItem\[\]\s*\{\s*\}', 'new System.Windows.Forms.ToolStripItem[0]'
        $line = $line -replace 'new ToolStripItem\[\]\s*\{\s*\}', 'new ToolStripItem[0]'
        $line = $line -replace '\{\s*,\s*', '{ '
        $line = $line -replace ',\s*\}', ' }'
        $newDesignerContent += $line
    }
}
$newDesignerContent | Set-Content $designerPath
