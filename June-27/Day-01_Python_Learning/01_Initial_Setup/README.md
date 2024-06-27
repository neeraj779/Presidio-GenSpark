# Initial Setup of Python

## Introduction

Setting up Python on your system is the first step to start your journey with Python programming. This guide will help you install Python and verify the installation.

## Contents

- [Installing Python](#installing-python)
- [Verifying the Installation](#verifying-the-installation)
- [Setting Up Environment Variables](#setting-up-environment-variables)
- [Installing pip](#installing-pip)
- [Common Issues and Solutions](#common-issues-and-solutions)

## Installing Python

1. **Download Python**: Visit the official [Python website](https://www.python.org/downloads/) and download the latest version suitable for your operating system.
2. **Run the Installer**: Open the downloaded file and run the installer. Ensure you check the option to add Python to your PATH.

## Verifying the Installation

To verify that Python is installed correctly:

1. Open a terminal (Command Prompt for Windows, Terminal for macOS/Linux).
2. Type the following command and press Enter:
   ```python
   python --version
   ```
3. If Python is installed correctly, you will see the version number displayed.

## Setting Up Environment Variables

If you didn't add Python to your PATH during installation, you can add it manually to access Python from any directory in the terminal.:

**Windows**:

- Open the Start menu and search for 'Environment Variables'.
- Click on 'Edit the system environment variables'.
- Click on 'Environment Variables'.
- Under 'System variables', click on 'Path' and then 'Edit'.
- Click 'New' and add the path where Python is installed.
- Click 'OK' to save the changes.

## Installing pip

`pip` is the package installer for Python. It is usually included with Python installation. To verify:

1. Open a terminal.
2. Type the following command and press Enter:
   ```python
   pip --version
   ```
3. If `pip` is installed correctly, you will see the version number displayed.

If pip is not installed, follow the instructions [here](https://pip.pypa.io/en/stable/installation/).

## Common Issues and Solutions

- **Command Not Found**: If you get a 'command not found' error, ensure that Python is added to your PATH.
