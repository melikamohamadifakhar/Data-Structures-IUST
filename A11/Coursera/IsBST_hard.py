## i wrote this code with help of serching. my own code can pass all A11 tests but not coursera tests.


class Node:
    def __init__(self, a, b, c):
        self.key = a
        self.left = b
        self.right = c


def Is_BST_hard(tree):
    stack = []
    stack.append((float('-inf'), tree[0], float('inf')))
    while stack:
        min, root, max = stack.pop()
        if root.key < min:
            return False
        if root.key >= max:
            return False
        if root.left != -1:
            stack.append((min, tree[root.left], root.key))
        if root.right != -1:
            stack.append((root.key, tree[root.right], max))
    return True


def main():
    n_nodes = int(input())
    if n_nodes == 0:
        print('CORRECT')
        return
    nodes = [0 for _ in range(n_nodes)]
    for i in range(n_nodes):
        a, b, c = map(int, input().split())
        node = Node(a, b, c)
        nodes[i] = node
    if Is_BST_hard(nodes):
        print('CORRECT')
        return
    print('INCORRECT')
