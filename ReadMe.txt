CLR Fundementals

1. .NET Framework
	a. Execution engine - in charge of code execution (JIT compilation, security, memory management etc)
	b. Set of class libraries - useful code I don't have to write (lists, stacks etc)

	C# => C# Compiler => CIL Code (Compile time) => CLR (Runtime), takes CIL code and JIT converts it to => Native code

	A. CLR - Common Language Runtime - "virtual machine" component of .NET framework, manages execution of .net programs
		- Heart of .NET Framework
		- JIT converts compiled code into machine instructions that CPU understands and executes
		- CLR is implemented as as of in-process DLLs
		- clr is only loaded into processes that run managed code

		Foo.exe => CLR loaded into process
			- each exectuable has it's own CLR version, Thread Pool, Heap
			- .exe and .dll contains IL code

	B. Functions of the CLR
		- Convert code into CLI.
		- Exception handling
		- Type safety
		- Memory management (using the Garbage Collector)
		- Security
		- Improved performance
		- Language independency
		- Platform independency
		- Architecture independency

	C. JIT - Just in time compilatioin
		- processor specific code is generator at runtime
		- check types etc
		- not interpreted
		- by default, method by method basis 


2. Garbage Collection
	- difficult, error prone, cleaning up memory manually is difficult

	CLR - dynamically tuned memory acquasition, very efficient
		- periadic compaction and cleanup, allocation. helps with fragmantation

3. Assemblies and Types
	public - tells CLR that this assembly class can be used/accessed by other assemblies
	internal - only within same assembly
	
	Resolving assembly - means loading assembly into memory

	Fully specified assembly names have four parts:
		a. friendly name
		b. version
		c. culture (language/region)
		d. key token (uniquely identifies the publisher - involves public/private key pair technology)

		Display Name:
		"calc, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b7aa5c61323e3234"
	
	string url = "some string" => url.GetType() => "System.String, mscorelib, ver=2.0.0.0"	=> (mscolib.dll assembly of System.String type, System namespace)
	Uri uri = new Uri(url)     => uri.GetType() => "System.Uri, System, ver=2.0.0.0"		=> (System.dll assemly of System.Uri type)

	Public key - when not null assemblies are strongly named (from Microsoft). Part of .net framework
	Public key = null - means your own assembly

	1. Loading assemblies steps
		a. For all assemblies not stronly named will look in /bin
		b. Subdirectory with same assembly name: calc.dll => \calc\calc.dll
		c. App.config/web.config
			- path probing

	2. Signing Assemblies - strong naming assembly
		SN.exe - creates/manages key files
		- assembly name is specified using attributes ie: [assembly: AssemblyVersion("1.0.0.0.1")]
		- strongly names assemblies contain signature

		Manifest
		app.exe														calc.dll
		.assembly extern calc {								{	public key
			.publickeytoken = abcd1234 // hash     =>			signature	}
			.ver = 1.0.1.0										code
		}

	3. Version Mapping (version policy) 
		- sometimes you might want the application to run against a newer version of an assembly
		- you can redirect your app to use a different version of an assembly
		- able to map one version of assembly to another assembl

		Why? - new version fixed a bug, better performance, new features etc

		in web/app.config you can specify (without recompiling) project to point to new assembly

	4. GAC (Global Aseembly Cache)
		- multiple version of the "same" assembly present on the machine
		- clients indicate desired version of assembly to load