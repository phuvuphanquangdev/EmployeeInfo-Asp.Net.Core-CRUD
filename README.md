# Packages

<Project Sdk="Microsoft.NET.Sdk.Web">

	<PropertyGroup>
		<TargetFramework>netcoreapp3.1</TargetFramework>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="Microsoft.AspNetCore.Mvc.TagHelpers" Version="2.2.0" />
		<PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.30" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="3.1.30">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.30" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.1.30">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="3.1.5" />
	</ItemGroup>

</Project>
