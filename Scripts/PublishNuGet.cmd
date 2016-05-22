for %%f in (*.nupkg) do (
	echo %%~nf
	nuget push "%%~nf.nupkg"
)