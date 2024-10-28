<div align="center">
  <h1>LeetCode Problems</h1>
  <br />
  <a href="#Problems-and-Solutions"><strong>Getting Started »</strong></a>
  <br />
  <br />
  <a href="https://github.com/HamidMolareza/LeetCode/issues/new?assignees=&labels=help%20wanted&template=02_SOLVE_REQUEST.md&title=solve%20request%3A+">
  Request to solve a new question</a> -
  <a href="https://github.com/HamidMolareza/LeetCode/issues/new?assignees=&labels=question&template=04_SUPPORT_QUESTION.md&title=support%3A+">
  Ask a Question</a>
</div>

<div align="center">
<br />

![GitHub](https://img.shields.io/github/license/HamidMolareza/LeetCode)
[![Pull Requests welcome](https://img.shields.io/badge/PRs-welcome-ff69b4.svg?style=flat-square)](https://github.com/HamidMolareza/LeetCode/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)

</div>

## About

The solutions to some [LeetCode](https://leetcode.com) problems.

All the solutions that are here, get full score (100) in LeetCode. But that does not necessarily mean the best answer.

🌟 If you like this project, please give it a star.

In [this section](#list-of-problems-solutions) you can see the solutions, And if you want, you
can [send your solution](#contributing) (in any language).

## Problems and Solutions

See the complete list in [this page](docs/CompleteList.md).

{__REPLACE_FROM_PROGRAM_0__}

See the complete list in [this page](docs/CompleteList.md).

## Usage

All solutions are in the [Solutions](Solutions) folder.

In LeetCode, the structure of the problem link is as follows: https://leetcode.com/problems/{Problem-Name}

We keep all problem solutions in a folder called `Problem-Name`. For example, the solutions
to [this problem](https://leetcode.com/problems/two-sum/) with name `two-sum` are located in folder `two-sum`
inside [Solutions](Solutions/two-sum) folder.

Every problem can be solved with different languages. For example, `C#`, `Python`, etc. To separate the languages, we
save each language in a folder with its own name. For example, for `C#`, the solution is placed in a folder
called `csharp`.

For example, the tree structure of a solutions can look like this:

- Solutions
    - [two-sum](https://github.com/HamidMolareza/LeetCode/tree/master/Solutions/two-sum)
        - README.md (the question text)
        - csharp
          - Solution
            - program.cs
          - Test
          - README (about solutions)
        - python
          - program.py
    - [combine-two-tables](https://github.com/HamidMolareza/LeetCode/tree/master/Solutions/combine-two-tables/MySQL)
      - README.md (the question text)
      - MySQL
        - solution.sql
        - README.md (about solution)

For see default templates, you can see [this section](Templates).

## Known issues

Please see [this list](https://github.com/HamidMolareza/LeetCode/issues) and help if you can.

## Roadmap

See the [open issues](https://github.com/HamidMolareza/LeetCode/issues) for a list of proposed features (and known
issues).

- [Top Question Requests](https://github.com/HamidMolareza/LeetCode/issues?q=label%3Aenhancement+is%3Aopen+sort%3Areactions-%2B1-desc) (
  Add your votes using the 👍 reaction)

## Support

Reach out to the maintainer at one of the following places:

- [GitHub issues](https://github.com/HamidMolareza/LeetCode/issues/new?assignees=&labels=question&template=04_SUPPORT_QUESTION.md&title=support%3A+)

## Features

- Automatic readme generation
- Support multi-language
- CI/CD with GitHub action

## Contributing

First off, thanks for taking the time to contribute! Contributions make the free/open-source community such an
amazing place to learn, inspire, and create. Any contributions you make will benefit everybody else and are **greatly
appreciated**.

Please read [our contribution guidelines](docs/CONTRIBUTING.md), and thank you for being involved!

## Authors & contributors

The original setup of this repository is by [Hamid Molareza](https://github.com/HamidMolareza).

## About Readme.md

This file is generated [automatically](.github/workflows/update-readme.yml). You can see the source of this program in
the [Readme Generator](ReadmeGenerator) directory.

This project uses [the Payadel README template](https://github.com/Payadel/Readme/).

### Why readme is auto-generated?

I didn't want to manually update the table in this file every time a problem was solved. This is repetitive work and
programmers hate repetitive work!

### How does readme generated?

In summary, the list of problems and solutions is read from the [Solutions](Solutions) folder, and the processed
information is placed in [this format](ReadmeGenerator/Data/ReadmeTemplate.md).
For more information please see [Readme Generator](ReadmeGenerator).

## License

This project is licensed under the **GPLv3**.

See [LICENSE](LICENSE) for more information.

## Related

- Are you you interested in [Quera](quera.org) site problems? Please see [this repository](https://github.com/HamidMolareza/QueraProblems).


> If you want your repository to be added, send me the link in the issues.
