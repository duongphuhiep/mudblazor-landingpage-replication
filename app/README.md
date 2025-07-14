# MudBlazor.com Landing Page Replication

## How to run

Step 1. Modify the file `prebuild.sh`, make it empty.

Step 2. Run the [DaisyMudLanding](./DaisyMudLanding) project

```
cd DaisyMudLanding
dotnet run
```

## How to develop

Prequisition: You will need Tailwind CSS to generate the CSS file

* option 1: [Use standalone client](https://github.com/tailwindlabs/tailwindcss/releases/), no need NodeJS
* option 2: use NodeJS/pnpm

You will need to modify the `prebuild.sh`, and make it generate the CSS file.

This script will be executed in the pre build of the [DaisyMudLanding](./DaisyMudLanding) project
