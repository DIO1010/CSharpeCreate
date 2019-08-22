if "%1"=="winexe" (
    csc /target:winexe *.cs Src\Debug\*.cs Src\Utilities\*.cs Src\Layers\*.cs Const\*.cs Src\Xml\*.cs Src\States\*.cs Src\LayerManager\*.cs -optimize+ /unsafe
) else (
    csc *.cs Src\Commands\*.cs Src\Debug\*.cs Src\Utilities\*.cs Src\Layers\*.cs Src\Const\*.cs Src\Xml\*.cs Src\States\*.cs Src\LayerManager\*.cs -optimize+ /unsafe
)

