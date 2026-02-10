public class Search
{
    public bool SearchNode(TreeNode root, int target)
    {
        if (root == null)
        {
            return false;
        }

        if (target > root.Value)
        {
            return SearchNode(root.Right, target);
        }
        else if (target < root.Value)
        {
            return SearchNode(root.Left, target);
        }
        else
        {
            return true;
        }
    }
}

// Insert a new node and return the root of the BST.
    public TreeNode Insert(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        if (val > root.Value)
        {
            root.Right = Insert(root.Right, val);
        }
        else if (val < root.Value)
        {
            root.Left = Insert(root.Left, val);
        }
        return root;
    }

    // Return the minimum value node of the BST.
    public TreeNode MinValueNode(TreeNode root)
    {
        TreeNode curr = root;
        while (curr != null && curr.Left != null)
        {
            curr = curr.Left;
        }
        return curr;
    }

    // Remove a node and return the root of the BST.
    public TreeNode Remove(TreeNode root, int val)
    {
        if (root == null)
        {
            return null;
        }
        if (val > root.Value)
        {
            root.Right = Remove(root.Right, val);
        }
        else if (val < root.Value)
        {
            root.Left = Remove(root.Left, val);
        }
        else
        {
            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }
            else
            {
                TreeNode minNode = MinValueNode(root.Right);
                root.Value = minNode.Value; 
                root.Right = Remove(root.Right, minNode.Value);
            }
        }
        return root;
    }

// Depth First Search (DFS) Traversal 
    public void InOrder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        InOrder(root.Left);
        Console.WriteLine(root.Value);
        InOrder(root.Right);
    }

    public void PreOrder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.WriteLine(root.Value);
        PreOrder(root.Left);
        PreOrder(root.Right);
    }

    public void PostOrder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        PostOrder(root.Left);
        PostOrder(root.Right);
        Console.WriteLine(root.Value);
    }

// Breadth First Search (BFS) Traversal
    public void BfsTraversal(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        if (root != null)
        {
            queue.Enqueue(root);
        }
        int level = 0;
        while (queue.Count > 0)
        {
            Console.WriteLine("level " + level + ": ");
            int levelLength = queue.Count;
            for (int i = 0; i < levelLength; i++)
            {
                TreeNode curr = queue.Dequeue();
                Console.WriteLine(curr.Value);
                if (curr.Left != null)
                {
                    queue.Enqueue(curr.Left);
                }
                if (curr.Right != null)
                {
                    queue.Enqueue(curr.Right);
                }
            }
            level++;
            Console.WriteLine();
        } 
    }

// Determin if there exists a path from root to leaf node without having a value of zero in the path.
public bool CanReachLeaf(TreeNode root)
    {
        if (root == null || root.Val == 0)
        {
            return false;
        }
        if (root.Left == null && root.Right == null)
        {
            return true;
        }
        if (CanReachLeaf(root.Left))
        {
            return true;
        }
        if (CanReachLeaf(root.Right))
        {
            return true;
        }
        return false;
    }

    public bool LeafPath(TreeNode root, List<int> path)
    {
        if (root == null || root.Val == 0)
        {
            return false;
        }
        path.Add(root.Val);

        if (root.Left == null && root.Right == null)
        {
            return true;
        }
        if (LeafPath(root.Left, path))
        {
            return true;
        }
        if (LeafPath(root.Right, path))
        {
            return true;
        }
        path.Remove(path.Count - 1);
        return false;
    } 