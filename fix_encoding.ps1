$ErrorActionPreference = "Stop"

$c = [char]0xFFFD

$replacements = [ordered]@{
    "Mod$($c)l" = "Modül"
    "Kod $($c)n Ek" = "Kod Ön Ek"
    "Say$($c)sal Uzunluk" = "Sayısal Uzunluk"
    "Ba$($c)lang$($c)$($c) Say$($c)s$($c)" = "Başlangıç Sayısı"
    "Tarih Bazl$($c) Kod S$($c)f$($c)rla" = "Tarih Bazlı Kod Sıfırla"
    "Kullan$($c)c$($c) M$($c)dahale Edebilsin" = "Kullanıcı Müdahale Edebilsin"
    "Tarih Format$($c)" = "Tarih Formatı"
    "Firma K$($c)sa Kod Kullan" = "Firma Kısa Kod Kullan"
    "Otomatik Kod $($c)retimi" = "Otomatik Kod Üretimi"
    "Kod $($c)ablon Tan$($c)m$($c)" = "Kod Şablon Tanımı"
    "Kod $($c)ablonlar$($c)" = "Kod Şablonları"
    "Bask$($c) $($c)nizle" = "Baskı Önizle"
    "D$($c)$($c)ar$($c) Aktar" = "Dışarı Aktar"
    "Excel Dosyalar$($c)" = "Excel Dosyaları"
    "Excel Dosyas$($c) ( Standart )" = "Excel Dosyası ( Standart )"
    "Excel Dosyas$($c) ( Formatl$($c) ) " = "Excel Dosyası ( Formatlı ) "
    "Excel Dosyas$($c) ( Formats$($c)z )" = "Excel Dosyası ( Formatsız )"
    "Excel Dosyas$($c)" = "Excel Dosyası"
    "Word Dosyas$($c)" = "Word Dosyası"
    "Pdf Dosyas$($c)" = "Pdf Dosyası"
    "Txt Dosyas$($c)" = "Txt Dosyası"
    "Pasif Kay$($c)tlar" = "Pasif Kayıtlar"
    "Ba$($c)l$($c) Kay$($c)tlar" = "Bağlı Kayıtlar"
    "Se$($c)" = "Seç"
    "D$($c)zelt" = "Düzelt"
    "Yazd$($c)r" = "Yazdır"
}

$filesToFix = @(
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\BaseForms\BaseListForm.Designer.cs",
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateEditForm.Designer.cs",
    "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateListForm.Designer.cs"
)

# Use UTF-8 with BOM for writing
$utf8WithBom = New-Object System.Text.UTF8Encoding($true)

foreach ($file in $filesToFix) {
    if (Test-Path $file) {
        $content = Get-Content -Path $file -Raw -Encoding UTF8
        
        $changed = $false
        foreach ($key in $replacements.Keys) {
            if ($content.Contains($key)) {
                $content = $content.Replace($key, $replacements[$key])
                $changed = $true
            }
        }
        
        if ($changed) {
            # Write back using UTF-8 with BOM
            [System.IO.File]::WriteAllText($file, $content, $utf8WithBom)
            Write-Host "Fixed and saved with UTF-8 BOM: $file"
        } else {
            Write-Host "No replacement characters found in: $file"
        }
    } else {
        Write-Warning "File not found: $file"
    }
}
Write-Host "Smart Fix Completed."
