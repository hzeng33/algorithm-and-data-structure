import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Deque;

public class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;

    public TreeNode(int val) {
        this.val = val; 
        left = null;
        right = null; 
    }
}


    public boolean search(TreeNode root, int target) {
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
    public TreeNode insert(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val);
        }

        if (val > root.val) {
            root.right = insert(root.right, val);
        } else  if (val < root.val) {
            root.left = insert(root.left, val);
        }
        return root;
    }

    // Return the minimum value node of the BST.
    public TreeNode minValueNode(TreeNode root) {
        TreeNode curr = root;
        while(curr != null && curr.left != null) {
            curr = curr.left;
        }
        return curr;
    }

    // Remove a node and return the root of the BST.
    public TreeNode remove(TreeNode root, int val) {
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
                TreeNode minNode = minValueNode(root.right);
                root.val = minNode.val;
                root.right = remove(root.right, minNode.val);
            }
        }
        return root;
    }    

// Depth First Search (DFS) Traversal of a Binary Tree
    public void inorder(TreeNode root) {
        if (root == null) {
            return;
        }
        inorder(root.left);
        System.out.println(root.val);
        inorder(root.right);
    }

    public void preorder(TreeNode root) {
        if (root == null) {
            return;
        }
        System.out.println(root.val);
        preorder(root.left);
        preorder(root.right);
    }

    public void postorder(TreeNode root) {
        if (root == null) {
            return;
        }  
        postorder(root.left);
        postorder(root.right);
        System.out.println(root.val);
    }

    // Breadth First Search (BFS) Traversal of a Binary Tree
    public void bfs(TreeNode root) { 
        Deque<TreeNode> queue = new ArrayDeque<TreeNode>();
        if (root != null) {
            queue.add(root);
        }    
        int level = 0;
        while(!queue.isEmpty()) {
            System.out.print("level " + level + ": ");
            int levelLength = queue.size();
            for (int i = 0; i < levelLength; i++) {
                TreeNode curr = queue.removeFirst(); 
                System.out.print(curr.val + " ");
                if(curr.left != null) {
                    queue.add(curr.left);  
                }
                if(curr.right != null) {
                    queue.add(curr.right);
                }  
            }
            level++;
            System.out.println();
        }
    }

    //Determin if there exists a path from root to leaf node without having a value of zero in the path.
    public boolean canReachLeaf(TreeNode root) {
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

    public boolean leafPath(TreeNode root, ArrayList<Integer> path) {
        if (root == null || root.val == 0) {
            return false;
        }
        path.add(root.val);

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