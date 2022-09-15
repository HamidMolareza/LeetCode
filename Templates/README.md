# About Templates

With the help of these templates, you can start solving the problem faster and easier.
For example, if you are going to solve a database problem, you can use the [MySQL](MySQL) template.

## Getting Started

1. Specify what problem you want to solve. For example, we want to solve the [combine-two-tables problem](https://leetcode.com/problems/combine-two-tables).

2. Specify in which language you want to solve the problem. For example, `MySQL`.

3. Choose the closest template. In the previous example, it is the [MySQL](MySQL) template.

4. Consider the problem name (from url). In the previous example, it is the `combine-two-tables`

5. Change your directory to `Templates` directory:

`cd Templates`

6. Run `create-template.sh` shell with this command:

`./create-template.sh 'problem-name' 'template path' 'solutions-directory-path'`

In the previous example:

`./create-template.sh 'combine-two-tables' 'MySQL' '../Solutions'`

> Note: the `'solutions-directory-path'` is optional. The default value is `'solutions-directory-path'`.
> 
> So you can use this command:
> `./create-template.sh 'combine-two-tables' 'MySQL'`

7. Go to solution directory:

`../Solutions/problem-name/template-name`

In the previous example, solution directory is: `../Solutions/combine-two-tables/MySQL`

10. Solve the problem

11. Commit

12. (Optional) You can merge this branch into master branch with `merge-into-master-branch.sh` shell.

Run the shell:
`./merge-into-master-branch.sh 'problem-name'`

In the previous example:
`./merge-into-master-branch.sh 'combine-two-tables'`