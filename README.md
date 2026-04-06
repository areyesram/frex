# frex - Find RegX

`frex` is a command-line tool designed to perform powerful string extraction and replacement operations across multiple files using Regular Expressions. Originally built as a Windows Forms application, it has been transformed into a modern `.NET` cross-platform console utility, enabling high-speed scripting and automation workflows.

## Features

- **Regex Extract & Replace**: Utilize full Regular Expressions to locate and transform text across your documents.
- **Bulk Target File Match**: Define file globs (e.g., `*.cs`) and recurse through subdirectories to process massive amounts of files conditionally.
- **Tabular Script Replacements**: Supplement your searches with an external `.tsv` or pipe separated text script to apply batch replacements in one command executing pass.

## Requirements

You must have the `.NET Core SDK` (specifically `.NET 10.0` or a compatible SDK version) installed to compile and execute the application.

## Usage

```bash
frex [options]
```

### Options

| Short | Long                  | Description                                                   |
| ----- | --------------------- | ------------------------------------------------------------- |
| `-p`  | `--path <path>`       | Base directory path to search (default: `.`)                  |
| `-m`  | `--pattern <pattern>` | File wildcard validation pattern to match (e.g., `*.txt`)     |
| `-r`  | `--regex <regex>`     | Regular expression pattern to search within the files         |
| `-w`  | `--replace <replace>` | Text to replace matches with                                  |
| `-R`  | `--recursive`         | Subdirectories recurse flag. If set, searches recursively     |
| `-c`  | `--casesensitive`     | Enable case sensitive regex evaluation                        |
| `-t`  | `--trim`              | Trims leading and trailing whitespaces off identified matches |
| `-s`  | `--script <file>`     | Path to a supplemental replacement script                     |

---

## Examples

### 1. Extract Matches

Identify and extract all integer occurrences out of your textual configuration files in the current directory:

```bash
dotnet run -- -m "*.conf" -r "\d+"
```

### 2. Basic Search and Replace

Find all instances of the word `"foo"`, case-insensitive, and explicitly replace them with `"bar"` inside `*.txt` items.
_(Note: Use `-c` to enforce case sensitivity)_

```bash
dotnet run -- -m "*.txt" -r "foo" -w "bar"
```

### 3. Recursive Regex Replacements

Perform an advanced regex manipulation recursively through all files in the `./src` log files.

```bash
dotnet run -- -p ./src -m "*.log" -r "ERROR_(\d+)" -w "WARNING_CODE_$1" -R
```

### 4. Bulk File Scripting using Scripts

Execute an inline text file find-and-replace using a predefined script. `frex` takes a TSV (tab separated) or pipe-delimited list to pipe bulk replacements into the extracted queries.

```bash
# substitutions.tsv contains:
# apples\tORANGES
# dogs|CATS

dotnet run -- -m "*.txt" -r "\w+" -s substitutions.tsv
```
