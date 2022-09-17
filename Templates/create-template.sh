#!/bin/bash

#functions:
exit_if_operation_failed() {
  if [ "$1" != 0 ]; then
    echo "Error! Operation exit with code $1: $2"
    exit "$1"
  fi
}

warning_if_operation_failed() {
  if [ "$1" != 0 ]; then
    echo "Warning! Operation exit with code $1: $2"
  fi
}

create_dir_if_is_not_exist() {
  if [ ! -d "$1" ]; then
    mkdir "$1"
  fi
}

ensure_problem_name_is_valid() {
  problem_name="$1"
  
  printf "Validating problem name... "
  status_code=$(curl -s -o /dev/null -w "%{http_code}" https://leetcode.com/problems/$problem_name/)
  if [ "$status_code" != "200" ]; then
    echo "Error! It seems that the name is not valid. (Id: $problem_name, status code: $status_code)"
    exit 1
  fi
  echo "done."
}

ensure_ide_is_valid() {
  ide="$1"
  if ! command -v "$ide" &>/dev/null; then
    echo "the ide command could not be found. (Ide: $ide)"
    exit 1
  fi
}
#===========================================================
# Get Inputs
problem_name="$1"
if [ -z "$problem_name" ]; then
  printf "Problem name (slug): "
  read -r problem_name
fi
ensure_problem_name_is_valid "$problem_name"

templateDir="$2"
if [ -z "$templateDir" ]; then
  if [ ! -d "$templateDir" ]; then
    printf "template directory: "
    read -r templateDir
  fi
fi
if [ ! -d "$templateDir" ]; then
  echo "Error! Can not find template dir in $templateDir"
  exit 1
fi

text_editor="$3"
if [ -z "$text_editor" ]; then
  text_editor="code"
fi
ensure_ide_is_valid "$text_editor"

ide="$4"
if [ -z "$ide" ]; then
  printf "Ide: "
  read -r ide
fi
ensure_ide_is_valid "$ide"

solutions_dir="$5"
if [ -z "$solutions_dir" ]; then
  solutions_dir="../Solutions"
  if [ ! -d "$solutions_dir" ]; then
    printf "Solutions directory: "
    read -r solutions_dir
  fi
fi
if [ ! -d "$solutions_dir" ]; then
  echo "Error! Can not find solutions dir in $solutions_dir"
  exit 1
fi
#===========================================================

#checkout
git checkout -b "$problem_name"
exit_if_operation_failed "$?" "Can not checkout to $problem_name"

#create solution dir
create_dir_if_is_not_exist "$solutions_dir/$problem_name"

#copy template to solution dir
result_dir="$solutions_dir/$problem_name"
cp -r "$templateDir" "$result_dir"
exit_if_operation_failed "$?" "Can not copy template from $templateDir to $result_dir"
wait

#Create README file for question text
questionText="$result_dir/README.md"
if [ ! -f "$questionText" ]; then
  echo 'Copy the question text here.' >"$questionText"
  echo "Please copy the question text to $questionText"

  $text_editor "$questionText" >/dev/null
  warning_if_operation_failed "$?" "Can not open your text editor for $questionText"
fi

echo "Directory is ready: $result_dir"
$ide "$result_dir" >/dev/null
warning_if_operation_failed "$?" "Can not open your ide for $result_dir"

echo ""
printf "Do you want merge this branch to master branch?(y/N) "
read -r merge_confirm
if [ "$merge_confirm" = 'y' ] || [ "$merge_confirm" = 'Y' ]; then
  ./merge-into-master-branch.sh "$problem_name" "y"
fi
