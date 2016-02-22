set fdir=%WINDIR%\Microsoft.NET\Framework64

if not exist %fdir% (
	set fdir=%WINDIR%\Microsoft.NET\Framework
)

::set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.
set msbuild="C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe"
%msbuild% ../src/Raven.AspNet/Raven.AspNet.WebApiExtensions/Raven.AspNet.WebApiExtensions.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\..\output\net45\Raven.AspNet.WebApiExtensions"

::set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
::%msbuild% ../src/Raven.Rpc.HttpProtocol/Raven.Rpc.IContractModel/Raven.Rpc.IContractModel.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\..\output\net45\Raven.Rpc.IContractModel"


pause