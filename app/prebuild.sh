#!/bin/bash

# Exit immediately if a command exits with a non-zero status.
set -e

# --- Corepack (pnpm) Environment Setup ---
# Your Corepack shims should already be in ~/.local/bin
# If ~/.local/bin is not in the PATH yet for Rider's build process, add it here.
export PATH="$HOME/.local/bin:$HOME/.local/share/fnm/:$PATH"

# --- FNM Environment Setup ---
# This is the crucial part. It executes fnm env and applies its output
# which usually involves setting PATH to include the active Node.js version.
# Ensure 'fnm' itself is accessible (it should be if you followed the FNM install guide).
# If FNM's own binary isn't in the default PATH for Rider, you might need:
# export PATH="$HOME/.local/share/fnm:$PATH" # Add FNM binary to PATH if needed
eval "$(fnm env)"

# --- Your Actual Pre-Build Commands ---
echo "--- Running pnpm install ---"
pnpm build

echo "--- Pre-build script finished successfully ---"

# You can add more commands here, e.g., building frontend assets
# pnpm run build:frontend
