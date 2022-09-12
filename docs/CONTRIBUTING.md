# Contributing

When contributing to this repository, please first discuss the change you wish to make via **issue**, email, or any
other method with the owners of this repository before making a change. Please note we have
a [code of conduct](CODE_OF_CONDUCT.md), please follow it in all your interactions with the project.

## Readme File

The readme file is generated **automatically**. So do not change this file directly. To apply the format changes, update
the [readme template](https://github.com/HamidMolareza/LeetCode/blob/master/ReadmeGenerator/Data/ReadmeTemplate.md)
and send PR.

## Development environment setup

If we want to solve a problem with name [two-sum](https://leetcode.com/problems/two-sum/) with any languages, the base structure
is as follows:

- Solutions
    - [two-sum](https://github.com/HamidMolareza/LeetCode/tree/master/Solutions/two-sum)
        - README (Problem text)
        - LanguageName1
        - LanguageName2

**Important:** Every problem must have a readme file for problem text. If is not exist, create this file and copy text
of LeetCode problem to that file. And if is exist, please don't change it.

## Do you want to improve the solution? Refactor the code?

According to [the mentioned structure](#development-environment-setup), update the codes or documents and send PR.

## A problem has been solved, but do you want to provide another solution?

All the solutions of a language must be placed in a folder called the same language (for example, `csharp`). If you are
not using a new language, do not create a new folder. Use another source file to the previous sources and preferably
update the readme file of the problem.

For example, two solutions are used
in [this problem](https://github.com/HamidMolareza/LeetCode/tree/master/Solutions/two-sum/csharp):

- program.cs
- program2.cs

## The problem is solved, but do you have a solution with a new language?

According to [the mentioned structure](#development-environment-setup), create a folder called the desired language and
put your codes. You can also use
the [default templates](https://github.com/HamidMolareza/LeetCode/tree/master/Templates).

## Do you want to solve a new problem?

According to [the mentioned structure](#development-environment-setup):

- create a folder named `LeetCode-problem-name`
  in [Solutions](https://github.com/HamidMolareza/LeetCode/tree/master/Solutions) folder.
- Create a folder in it called the desired language (like `csharp`, `python`, `react`, etc).
- Put your solution there.

You can also use the [default templates](https://github.com/HamidMolareza/LeetCode/tree/master/Templates).

**Important:** The auto readme generator uses **the problem folder name** to generate a problem link to LeetCode site.
So it is important that use the correct name:

For example problem name in https://leetcode.com/problems/two-sum/ is `two-sum`.

## Issues and question requests

Do you want a solution to a new problem, do you know a better solution or did you find a problem? You can help us
by [submitting an issue on GitHub](https://github.com/HamidMolareza/LeetCode/issues). Before you create an issue, make
sure to search the issue archive -- your issue may have already been addressed!