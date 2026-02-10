class TreeNode {
    constructor(val) {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

function search(root, target) {
    if (root == null) {
        return false;
    }

    if (target > root.val) {
        return search(root.right, target);
    } else if (target < root.val) {
        return search(root.left, target);
    } else {
        return true;
    }
}

// Insert a new node and return the root of the BST.
function insert(root, val) {
    if (root == null) {
        return new TreeNode(val);
    }

    if (val > root.val) {
        root.right = insert(root.right, val);
    } else if (val < root.val) {
        root.left = insert(root.left, val);
    }
    return root;
}

// Return the minimum value node of the BST.
function minValueNode(root) {
    let curr = root;
    while (curr != null && curr.left != null) {
        curr = curr.left;
    }
    return curr;
}

// Remove a node and return the root of the BST.
function remove(root, val) {
    if (root == null) {
        return null;
    }
    if (val > root.val) {
        root.right = remove(root.right, val);
    } else if (val < root.val) {
        root.left = remove(root.left, val);
    } else {
        if (root.left == null) {
            return root.right;
        } else if (root.right == null) {
            return root.left;
        } else {
            let minNode = minValueNode(root.right);
            root.val = minNode.val;
            root.right = remove(root.right, minNode.val);
        }
    }
    return root;
}

// Depth First Search Traversals
function inorder(root) {
    if (root == null) {
        return;
    }
    inorder(root.left);
    console.log(root.val);
    inorder(root.right);
}

function preorder(root) {
    if (root == null) {
        return;
    }
    console.log(root.val);
    preorder(root.left);
    preorder(root.right);
}

function postorder(root) {
    if (root == null) {
        return;
    }
    postorder(root.left);
    postorder(root.right);
    console.log(root.val);
}

// Breadth First Search Traversal
function bfs(root) {
    let queue = [];
    if (root != null) {
        queue.push(root);
    }
    let level = 0;
    while (queue.length > 0) {
        console.log("level " + level + ": ");
        let levelLength = queue.length;
        for (let i = 0; i < levelLength; i++) {
            let curr = queue.shift();
            console.log(curr.val + " ");
            if (curr.left != null) {
                queue.push(curr.left);
            }
            if (curr.right != null) {
                queue.push(curr.right);
            }
        }
        level++;
        console.log();
    }
}

// Determin if there exists a path from root to leaf node without having a value of zero in the path.
function canReachLeaf(root) {
    if (root == null || root.val == 0) {
        return false;
    }
    if (root.left == null && root.right == null) {
        return true;
    }
    if (canReachLeaf(root.left)) {
        return true;
    }
    if (canReachLeaf(root.right)) {
        return true;
    }
    return false;
}

function leafPath(root, path) {
    if (root == null || root.val == 0) {
        return false;
    }
    path.push(root.val);

    if (root.left == null && root.right == null) {
        return true;
    }
    if (leafPath(root.left, path)) {
        return true;
    }
    if (leafPath(root.right, path)) {
        return true;
    }
    path.remove(path.size() - 1);
    return false;
}