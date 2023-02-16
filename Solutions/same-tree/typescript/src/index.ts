class TreeNode {
    val: number
    left: TreeNode | null
    right: TreeNode | null

    constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
        this.val = (val === undefined ? 0 : val)
        this.left = (left === undefined ? null : left)
        this.right = (right === undefined ? null : right)
    }
}

function solution1(p: TreeNode | null, q: TreeNode | null): boolean {
    if (p?.val !== q?.val) return false;
    if (p === null || q === null) return true;
    return solution1(p?.left ?? null, q?.left ?? null)
        && solution1(p?.right ?? null, q?.right ?? null);
}

interface INodeStack {
    p: TreeNode | null;
    q: TreeNode | null;
}

function solution2(p: TreeNode | null, q: TreeNode | null): boolean {
    let stack: INodeStack[] = [{p, q}];
    while (stack.length > 0) {
        let nodes = stack.pop();
        if (nodes?.p?.val !== nodes?.q?.val) return false;
        if (!nodes?.p || !nodes?.q) continue;
        stack.push({
            p: nodes.p.left,
            q: nodes.q.left,
        });
        stack.push({
            p: nodes.p.right,
            q: nodes.q.right,
        });
    }
    return true;
}

// let p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
// let q = p;
// console.log(solution2(p, q));
