# nand2tetris HACK VM Translator

This is a .NET C# implementation of the nand2tetris Hack Plaform 
VM Translator. It takes `.vm` (Hack virtual machine code) file(s) as 
an input and turns it into an `.asm` (Hack assembly code).

## Projects

The solution consists of 2 projects:

- **Hack.VMTranslator.Lib** - all services and models that power the solution

- **Hack.VMTranslator.CLI** - an actual console application that makes use of 
Hack.VMTranslator.Lib to do the VM code -> Assembly translation job

The code is written in an object-oriented way, so various 
responsibilities of the solution are enclosed in their own classes.

## Usage

In order to use the translator, you need to run the Hack.VMTranslator.CLI
project like this (assuming that you are in the `Hack.VMTranslator.CLI`
directory):

```sh
Hack.VMTranslator.CLI:
  Nand2tetris VM Translator CLI

Usage:
  Hack.VMTranslator.CLI [options] <input>

Arguments:
  <input>    A path to a single VM file or a directory containing 1 or many VM files to translate into Assembler code

Options:
  -o, --output <output>      A result file to create [default: ]
  -b, --include-bootstrap    Decides whether bootstrap (initialization) code should be included in the Assembler code [default: True]
  --version                  Show version information
  -?, -h, --help             Show help and usage information
```

The only required argument is `input`, which is described above. If no `-o`
(output) is specified, it will be generated based on `input`:

- if an input is a path to a single file, the output will be in the same
  directory as the input file, with the same name, but different extension (asm)
- if an input is a path to a directory containing VM files, the output file will
  be plaved in that directory, and the name will be in a format `<directory
  name>.asm`.

You can decide whether you want to add bootstrap (initialization code that sets
up Stack Pointer, and calls "Sys.init") or not using the `-b true/false` flag.
By default, the bootstrap code will be generated.

The translator appends comments with the VM commands into the output file. This
way it is easier to go through the Assembly code and understand which VM command
a given Assembly portion relates to.
