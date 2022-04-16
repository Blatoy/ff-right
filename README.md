# FFRight

Rushed utility tool for quick ffmpeg cut and compress in context menu

## Add to context menu

Create `Computer\HKEY_CURRENT_USER\SOFTWARE\Classes\*\shell\FFRight\command`

Set a default: `"<path to exe>\ffright.exe" "%1"`

## Add extra params

Create a file `ffright-params.txt` next to the exe and add anything you need (e.g. `-filter_complex "[0:a:1][0:a:0]amix = 2:longest[aout]" -map 0:V:0 -map "[aout]"`)