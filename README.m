# nand2tetris HACK VM Translator

This is a .NET C# implementation of the nand2tetris Hack Plaform 
VM Translator. It takes `.vm` (Hack virtual machine code) file as 
an input and turns it into an `.asm` (Hack assembly code).

## Projects

The solution consists of 2 projects:

Hack.VMTranslator.Lib - all services and models that power the solution
Hack.VMTranslator.CLI - an actual console application that makes use of 
Hack.VMTranslator.Lib to do the VM code -> Assembly translation job

The code is written in an object-oriented way, so various 
responsibilities of the solution are enclosed in their own classes.

## Usage

In order to use it, you need to run the Hack.VMTranslator.CLI project 
like this (assuming that you are in the `Hack.VMTranslator.CLI directory):

```sh
dotnet run path/to/input.vm
```

The application will produce the output in the same directory where
the input file is located. The name of the file will be the same
as input's name (the extension will be `.asm` though).

The translator appends comments with the VM commands into the
output file. This way it is easier to go through the Assembly
code and understand which VM command a given Assembly portion
relates to.
