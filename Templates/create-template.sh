#!/bin/bash

show_help() {
  cat <<EOF
Usage: $(basename "$0") [options]

Options:
  -p, --problem     Problem Slug (required)
  -t, --template    Template directory (optional)
  -i, --ide         IDE (e.g. code, rider) (optional)
  -o, --output      Solutions directory (optional, default: Solutions or ../Solutions)
  -h, --help        Display this help message

Example:
  $(basename "$0") -p two-sum -t /path/to/template -i code
EOF
  exit 0
}

# Functions:
exit_if_failed() {
  if [ "$1" -ne 0 ]; then
    echo "Error! Operation failed with code $1: $2"
    exit "$1"
  fi
}

warn_if_failed() {
  if [ "$1" -ne 0 ]; then
    echo "Warning! Operation failed with code $1: $2"
  fi
}

create_dir_if_missing() {
  [ ! -d "$1" ] && mkdir -p "$1"
}

ensure_command_exists() {
  command -v "$1" &>/dev/null || {
    echo "Command not found: $1"
    exit 1
  }
}

ask_ignore_error() {
  if [ "$?" -ne 0 ]; then
    read -rp "Do you want to ignore this error? (Y/n) " ignore_error
    [[ "$ignore_error" =~ ^[nN]$ ]] && exit 1
  fi
}

get_default_solution_dir() {
  for dir in "Solutions" "../Solutions"; do
    [ -d "$dir" ] && echo "$dir" && return
  done
  echo ""  # Not Found
}

#===========================================================
# Parse Command-Line Options
while [[ $# -gt 0 ]]; do
  case "$1" in
    -p|--problem)
      problem_slug="$2"
      shift 2
      ;;
    -t|--template)
      template_dir="$2"
      shift 2
      ;;
    -o|--output)
      solutions_dir="$2"
      shift 2
      ;;
    -i|--ide)
      ide="$2"
      shift 2
      ;;
    -h|--help)
      show_help
      ;;
    *)
      echo "Unknown option: $1"
      show_help
      ;;
  esac
done

#===========================================================
# Validate Inputs
[ -z "$problem_slug" ] && { echo "Error: Problem slug is required."; show_help; }

if [ -n "$template_dir" ] && [ ! -d "$template_dir" ]; then
  echo "Invalid template path: $template_dir"
  exit 1;
fi

solutions_dir="${solutions_dir:-$(get_default_solution_dir)}"
if [ -z "$solutions_dir" ] || [ ! -d "$solutions_dir" ]; then
  echo "Solutions directory not found: $solutions_dir"
  exit 1
fi

if [ -n "$ide" ]; then
  ensure_command_exists "$ide"
fi

#===========================================================

# Checkout a new branch
git checkout -b "$problem_slug"
exit_if_failed "$?" "Unable to checkout to branch $problem_slug"

# Create solution directory
target_solution_dir="$solutions_dir/$problem_slug"
create_dir_if_missing "$target_solution_dir"

# Copy template to solution directory
if [ -n "$template_dir" ]; then
  cp -r "$template_dir" "$target_solution_dir"
  exit_if_failed "$?" "Failed to copy template to $target_solution_dir"
fi

#Create README file for question text
problem_description="$target_solution_dir/README.md"
if [ ! -f "$problem_description" ]; then
  echo 'Copy the question text here.' >"$problem_description"
  echo "Please copy the question text to $problem_description"
fi

echo "Directory is ready: $target_solution_dir"

if [ -n "$ide" ]; then
  "$ide" "$target_solution_dir"
  sleep 3s; wait
  "$ide" "$problem_description"
  
  warn_if_failed "$?" "Failed to open IDE for $target_solution_dir"
fi

# Push to master branch (optional)
read -rp "Do you want to push to the master branch (with merge flag)? (y/N) " push_confirm
if [[ "$push_confirm" =~ ^[yY]$ ]]; then
  git pull --no-rebase && git push
fi
