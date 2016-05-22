for %%f in (*.nupkg) do (
	echo %%~nf
	nuget push "%%~nf.nupkg" -Source "https://api.nuget.org/v3/index.json"
)