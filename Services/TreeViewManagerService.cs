using RaGuideDesigner.Models;
using System.Windows.Forms;

namespace RaGuideDesigner.Services
{
    public class TreeViewManagerService
    {
        // Builds the entire guide structure in the TreeView from the main WikiGuide model.
        // It creates the main sections first and then populates them with categories,
        // achievements, leaderboards, and credits.
        public void PopulateTreeView(TreeView treeView, WikiGuide guide)
        {
            treeView.Nodes.Clear();
            var rootNode = new TreeNode($"📜 {guide.GameTitle}") { Tag = guide };

            // These are special static nodes
            rootNode.Nodes.Add(new TreeNode("📄 Header & Intro") { Tag = "Header" });
            var achGuideNode = new TreeNode("💎 Achievement Guide") { Tag = "AchievementGuideRoot" };
            var leaderboardsNode = new TreeNode("🥇 Leaderboard Guide") { Tag = "LeaderboardGuideRoot" };
            var creditsNode = new TreeNode("📜 Credits") { Tag = "CreditsRoot" };

            achGuideNode.Nodes.Add(new TreeNode("📜 Walkthroughs & Resources") { Tag = "Walkthroughs" });

            if (guide.AchievementCategories != null)
            {
                foreach (var category in guide.AchievementCategories)
                {
                    var categoryTreeNode = CreateNodeForItem(category);
                    achGuideNode.Nodes.Add(categoryTreeNode);
                }
            }

            if (guide.Leaderboards != null)
            {
                foreach (var lb in guide.Leaderboards)
                {
                    leaderboardsNode.Nodes.Add(CreateNodeForItem(lb));
                }
            }

            if (guide.Credits != null)
            {
                foreach (var credit in guide.Credits)
                {
                    creditsNode.Nodes.Add(CreateNodeForItem(credit));
                }
            }

            rootNode.Nodes.Add(achGuideNode);
            rootNode.Nodes.Add(leaderboardsNode);
            rootNode.Nodes.Add(creditsNode);

            treeView.Nodes.Add(rootNode);
            treeView.ExpandAll();
        }

        // Creates a single TreeNode for a given guide item. If the item is a category,
        // it also recursively creates nodes for all achievements within that category.
        public TreeNode CreateNodeForItem(IGuideItem item)
        {
            var node = new TreeNode(item.DisplayText) { Tag = item };
            if (item is AchievementCategory category)
            {
                foreach (var ach in category.Achievements)
                {
                    node.Nodes.Add(CreateNodeForItem(ach));
                }
            }
            return node;
        }

        // A helper function to find a specific TreeNode by searching for its associated data model.
        public TreeNode? FindNodeByModel(TreeNodeCollection nodes, object model)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null && node.Tag.Equals(model))
                {
                    return node;
                }
                var foundNode = FindNodeByModel(node.Nodes, model);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }
    }
}