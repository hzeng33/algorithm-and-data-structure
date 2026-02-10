#include <iostream>
#include <queue>

using std::cout;
using std::endl;
using std::queue;


class TreeNode {
    public:
        int val_;
        TreeNode* left = nullptr;
        TreeNode* right = nullptr;

        TreeNode(int val) {
            val_ = val;
        }
};

bool search(TreeNode* root, int target) {
    if (!root) {
        return false;
    }

    if (target > root->val_) {
        return search(root->right, target);
    } else if (target < root->val_) {
        return search(root->left, target);
    } else {
        return true;
    }
}

// Insert a new node and return the root of the tree.
TreeNode* insert(TreeNode* root, int val) {
    if (!root) {
        return new TreeNode(val);
    }

    if (val > root->val_) { 
        root->right = insert(root->right, val);
    } else if (val < root->val_) {
        root->left = insert(root->left, val);
    }
    return root;
}

// Return the minimum value node of the BST.
TreeNode* minValueNode(TreeNode* root) {
    TreeNode* curr = root;
    while (curr && curr->left) {
        curr = curr->left;
    }
    return curr;
}

// Remove a node and return the root of the tree.
TreeNode* remove(TreeNode* root, int val) {
    if (!root) {
        return nullptr;
    }

    if (val > root->val_) { 
        root->right = remove(root->right, val);
    } else if (val < root->val_) {
        root->left = remove(root->left, val);
    } else {
        if (!root->left) {
            return root->right;
        } else if (!root->right) {
            return root->left;
        } else {
            TreeNode* minNode = minValueNode(root->right);
            root->val_ = minNode->val_;
            root->right = remove(root->right, minNode->val_);
        }
    }
    return root;
}

// Depth First Search (DFS) Traversal
void inorder(TreeNode* root) {
    if (!root) {
        return;
    }
    inorder(root->left);
    cout << root->val_ << endl;
    inorder(root->right);
}

void preorder(TreeNode* root) {
    if (!root) {
        return;
    }
    cout << root->val_ << endl;
    preorder(root->left);
    preorder(root->right);
}

void postorder(TreeNode* root) {
    if (!root) {
        return;
    }
    postorder(root->left);
    postorder(root->right);
    cout << root->val_ << endl;
}

// Breadth First Search (BFS) Traversal
void bfs(TreeNode* root) {
    queue<TreeNode*> queue;

    if (root) {
        queue.push(root);
    }
    
    int level = 0;
    while (queue.size() > 0) {
        cout << "level: " << level << endl;
        int length = queue.size();
        for (int i = 0; i < length; i++) {
            TreeNode* curr = queue.front();
            queue.pop();
            cout << curr->val_ << ' ';
            if (curr->left) {
                queue.push(curr->left);
            }
            if (curr->right) {
                queue.push(curr->right);
            }
        }
        level++;
        cout << endl;
    }

// Determin if there exists a path from root to leaf node without having a value of zero in the path.
bool canReachLeaf(TreeNode *root) {
    if (!root || root->val_ == 0) {
        return false;
    }
    if (!root->left && !root->right) {
        return true;
    }
    if (canReachLeaf(root->left)) {
        return true;
    }
    if (canReachLeaf(root->right)) {
        return true;
    }
    return false;
}

bool leafPath(TreeNode* root, vector<int>* path) {
    if (!root || root->val_ == 0) {
        return false;
    }
    path->push_back(root->val_);

    if (!root->left && !root->right) {
        return true;
    }
    if (leafPath(root->left, path)) {
        return true;
    }
    if (leafPath(root->right, path)) {
        return true;
    }
    path->pop_back();
    return false;
}