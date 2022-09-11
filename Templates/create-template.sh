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
#===========================================================
# Get Inputs
problemName="$1"
if [ -z "$problemName" ]; then
  printf "Problem name (slug): "
  read -r problemName
fi

solutionsDir="$2"
if [ -z "$solutionsDir" ]; then
  solutionsDir="../Solutions"
  if [ ! -d "$solutionsDir" ]; then
    printf "Solutions directory: "
    read -r solutionsDir
  fi
fi
if [ ! -d "$solutionsDir" ]; then
  echo "Error! Can not find solutions dir in $solutionsDir"
  exit 1
fi

templateDir="$3"
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
#===========================================================

#checkout
git checkout -b "$problemName"
exit_if_operation_failed "$?" "Can not checkout to $problemName"

#create solution dir
create_dir_if_is_not_exist "$solutionsDir/$problemName"

#copy template to solution dir
resultDir="$solutionsDir/$problemName"
cp -r "$templateDir" "$resultDir"
exit_if_operation_failed "$?" "Can not copy template from $templateDir to $resultDir"
wait

#Create README file for question text
questionText="$resultDir/README.md"
if [ ! -f "$questionText" ]; then
  echo 'Copy the question text here.' >"$questionText"
  echo "Please copy the question text to $questionText"
fi

echo "Directory is ready: $resultDir"
