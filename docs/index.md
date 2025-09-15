# RA Guide Designer - The Complete Tutorial

Welcome to the official guide for the RA Guide Designer! This tool was built to streamline the creation of high-quality, standardized wiki guides for the RetroAchievements community. This tutorial will walk you through every feature, from starting your first project to exporting the final Markdown, using a real-world example from the *Project: Snowblind* (PS2) set.

## Table of Contents
1.  [**Getting Started**](#1-getting-started)
    *   [The Main Interface](#the-main-interface)
    *   [Creating a New Project](#creating-a-new-project)
2.  [**Importing Your Data**](#2-importing-your-data)
    *   [Importing from an RA JSON File (Recommended Start)](#importing-from-an-ra-json-file)
    *   [Importing from an Existing Markdown Guide](#importing-from-an-existing-markdown-guide)
3.  [**Navigating and Managing Your Guide**](#3-navigating-and-managing-your-guide)
    *   [The Guide Structure Tree](#the-guide-structure-tree)
    *   [Adding, Deleting, and Duplicating Items](#adding-deleting-and-duplicating-items)
    *   [Reordering with Drag & Drop and Shortcuts](#reordering-with-drag--drop-and-shortcuts)
4.  [**The Editors**](#4-the-editors)
    *   [Header Editor](#header-editor)
    *   [Walkthroughs & Resources Editor](#walkthroughs--resources-editor)
    *   [Category Editor](#category-editor)
        *   [The Additional Notes Editor](#the-additional-notes-editor)
        *   [Marking a Category as Collectible](#marking-a-category-as-collectible)
    *   [Standard Achievement Editor](#standard-achievement-editor)
    *   [Collectible Achievement Editor](#collectible-achievement-editor)
    *   [Leaderboard Editor](#leaderboard-editor)
    *   [Credits Editor](#credits-editor)
5.  [**Advanced Features**](#5-advanced-features)
    *   [Rich Text Formatting & Shortcuts](#rich-text-formatting--shortcuts)
    *   [Undo & Redo System](#undo--redo-system)
    *   [Spell Checking](#spell-checking)
6.  [**Saving and Exporting**](#6-saving-and-exporting)
    *   [Saving Your Project File](#saving-your-project-file)
    *   [Exporting the Final Markdown](#exporting-the-final-markdown)

---

## 1. Getting Started

### The Main Interface
When you first launch the application, you're greeted with a simple two-panel layout.

*   **Left Panel (Guide Structure Tree):** This `TreeView` is your roadmap. It shows the entire hierarchy of your guide, from the game title down to individual achievements and credits. You'll use this to navigate between different sections.
*   **Right Panel (Editor Panel):** This is your workspace. When you select an item in the tree, the corresponding editor will appear here, allowing you to modify its content.

<img width="1264" height="711" alt="Attach01" src="https://i.ibb.co/m5wKy89c/Attach01.png" />

*The main interface with the Guide Structure Tree on the left and the placeholder text in the Editor Panel on the right.*

### Creating a New Project
To start from scratch, go to `File > New Guide` or press `Ctrl+N`. This loads a built-in template that contains all the standard sections and placeholder text, giving you a perfect foundation to build upon.

## 2. Importing Your Data

Most users will start by importing data from an existing source. The tool supports two primary methods.

### Importing from an RA JSON File
This is the recommended way to begin a new guide.

1.  First, you need a refreshed JSON file from the server, the best way to get it is to launch the game through [RA_Integration.dll](https://docs.retroachievements.org/developer-docs/emulator-setup-for-developers.html).
2.  Once the game is loaded, close the emulator. Then within your emulator folder, find and go to this directory `RACache\Data`, you should be able to find the *.JSON files. Look for the game ID (e.g. for *Project: Snowblind*, it's `21058.json`) and you should be good to go.
3.  In the RA Guide Designer, go to `File > Import JSON File...` or press `Ctrl+I`.
4.  Select the JSON file you want.

The application will automatically parse the file and:
*   Set the Game Title and Mastery Icon URL.
*   Create an entry for every achievement, populating its ID, Title, Description, Badge URL, and Points.
*   Intelligently sort achievements into "Progression" and "Challenges" categories based on their official type.
*   Populate the Leaderboards section.

<img width="1264" height="711" alt="Attach02" src="https://i.ibb.co/ZzcJqfBr/Attach02.gif" />

*Showcase of the File > Import JSON File... menu option.*

**Example: *Project: Snowblind***
Importing the JSON would automatically create the "Progression" and "Challenges" categories and fill them with achievements like "First Impact" and "One Gun, One Chopper," correctly assigning their points and badge images.

### Importing from an Existing Markdown Guide
If you have an older guide that you want to edit or reformat, you can import it directly.

1.  Go to `File > Import Existing Markdown...` or press `Ctrl+Alt+I`.
2.  Select your `.txt` file containing the guide.

> **Note:** The Markdown importer expects a format that closely matches the one generated by this tool. It may struggle with heavily customized or non-standard layouts.

## 3. Navigating and Managing Your Guide

### The Guide Structure Tree
The tree is your primary navigation tool. Clicking any item will instantly load its editor on the right.

<img width="1264" height="711" alt="Attach03" src="https://i.ibb.co/DHKrP5xK/Attach03.png" />

*The Guide Structure Tree populated with the *Project: Snowblind* guide, highlighting the "Challenges" category.*

*   **📜 Game Title:** The root node. Expanding it shows the main sections.
*   **📄 Header & Intro:** Edits the main game details, banner, and intro text.
*   **💎 Achievement Guide:** The parent node for all achievement-related content.
*   **🥇 Leaderboard Guide:** The parent node for leaderboards.
*   **📜 Credits:** The parent node for the credits section.

### Adding, Deleting, and Duplicating Items
Right-click on any item in the tree to open a context menu with powerful actions.

*   **Add:** You can add a new `Achievement Category`, `Achievement` (within a category), `Leaderboard`, or `Credit`.
*   **Delete (`Del` key):** Removes the selected item(s). You will be asked for confirmation.
*   **Duplicate:** Creates a copy of the selected item(s). This is fantastic for achievements that share a similar structure. Duplicated achievements have their ID set to 0.

<img width="1264" height="711" alt="Attach04" src="https://i.ibb.co/TB0YSwvq/Attach04.gif" />

*Showcase of the right-click context menu over an Achievement Category, showing options like "Add Achievement", "Duplicate", and "Delete".*

### Reordering with Drag & Drop and Shortcuts
You can easily reorder items like achievements, categories, and credits within their respective lists.

*   **Drag & Drop:** Click and drag an item to a new position. A line will indicate where it will be dropped. You can even drag achievements between different categories.
*   **Keyboard Shortcuts:** Select an item and use `Alt+Up` and `Alt+Down` to move it within its list. This is often faster and more precise than dragging.

## 4. The Editors

### Header Editor
*(Selected by clicking "📄 Header & Intro")*

This is where you manage the top-level information for your guide.
*   **Game Title & Platform:** The main identifiers. The Platform dropdown is grouped by manufacturer for easy selection.
*   **Mastery Icon & Banner Image URLs:** Paste the direct URLs to the images here (600x280 is the recommended resolution). The images will preview in the editor.
*   **Introductory Text:** The main text that appears right after the banner.
*   **Set Statistics:** A non-editable panel that provides a live summary of your set's total achievements, points, categories, etc.
*   **Footnotes Tab:** This tab allows you to edit the example text for the "Measured" and "Triggered" indicators found at the end of the guide. The **"Generate Footnotes..."** button is a powerful feature that scans all your achievements and automatically creates relevant examples based on common keywords, saving you some time.

<img width="1264" height="711" alt="Attach05" src="https://i.ibb.co/k21kQQRs/Attach05.png" />

*The Header Editor, filled with data from the Project: Snowblind guide.*

### Walkthroughs & Resources Editor
*(Selected by clicking "📜 Walkthroughs & Resources")*

This editor handles the section between the initial set summary and the first achievement category.

<img width="1264" height="711" alt="Attach06" src="https://i.ibb.co/4Qd6kCM/Attach06.png" />

*Walkthroughs & Resources Editor, showing the grids for links and the General Advice text box.*

*   **Guides & Playthroughs:** These grids let you manage lists of helpful links.
*   **Advice Section:** A rich text box for writing general advice. In the *Project: Snowblind* example, this is used for the "🧠 General Advice (Before Starting a New Game)" section. You can rename that header for your taste.
*   **Admonition Notes:** This area lets you add global, top-level notes (like `[!IMPORTANT]` or `[!NOTE]`). In the example, this is used for crucial info or warnings about certain aspects of the set.

#### How to Add Links
The grids for Guides and Playthroughs are simple and powerful.
1.  Click on the empty row at the bottom of the grid to add a new link.
2.  Enter the text you want the link to display in the **Display Text** column.
3.  Enter the full URL in the **URL** column.
4.  Click the `🗑️` button to delete a row.

**Example:** To create the GameFAQs link from the *Project: Snowblind* guide:
*   **Display Text:** `GameFAQs – Project: Snowblind FAQs`
*   **URL:** `https://gamefaqs.gamespot.com/ps2/920210-project-snowblind/faqs`

The tool will automatically format this into `**[Display Text](URL)**` in the final Markdown.

### Category Editor
*(Selected by clicking any 🏆 Category)*

Here you define the properties of an achievement category.

<img width="1264" height="711" alt="Attach07" src="https://i.ibb.co/RkGGsYx4/Attach07.png" />

*The Category Editor showing the "Weapon-specific" category from the example guide.*

*   **Title & Icon:** The display name and emoji for the category.
*   **Description:** The introductory text that appears below the category heading.
*   **Admonition Notes:** Just like the Walkthroughs editor, you can add notes that are specific to this category.
*   **Additional Notes... Button:** This is a key feature for complex categories. Clicking it opens a dedicated pop-up editor.

#### The Additional Notes Editor
This special editor is designed for content that requires more structure, like sub-headers or blockquotes.

<img width="1264" height="711" alt="Attach08" src="https://i.ibb.co/ZpMZPRR1/Attach08.png" />

*The "Additional Notes" pop-up editor, showing the formatted weapon ammo table from the example guide.*

*   **Formatting Toolbar:** Right-click to access a context menu that lets you apply `## Header 2`, `### Header 3`, and toggle `> Blockquote` formatting.
*   **Live Preview:** The editor shows you a formatted preview of your content, so you don't have to guess how it will look.
*   **Example: *Project: Snowblind*** The "Weapon-specific" category uses this feature to create a detailed, formatted table explaining weapon ammo limits and tactical roles, complete with sub-headers and a blockquote.

#### Marking a Category as Collectible
To enable the specialized **Collectible Achievement Editor** for all achievements within a category, you must manually mark it.
1. Right-click on the desired category in the Guide Structure Tree.
2. Select the **"Mark as Collectible Category"** option from the context menu. A checkmark will appear next to it.
3. Now, when you click on any achievement within that category, it will open in the Collectible Editor.

> **Note:** You can toggle this setting off by repeating the same steps. This feature cannot be enabled for the "Progression" category.

### Standard Achievement Editor
*(Selected by clicking any achievement NOT in a collectible category)*

This is the most-used editor. It's tabbed for organization.

<img width="1264" height="711" alt="Attach09" src="https://i.ibb.co/hRmcWL0N/Attach09.png" />

*The Standard Achievement Editor showing the "Collateral Damage" achievement from the example guide.*

*   **Guidance & Insights Tab:**
    *   The main rich text box for the achievement's guide.
    *   For **Progression** achievements, this tab is all you see, keeping the UI clean and simple.
    *   For other types, an "Image URL" and "Video Walkthrough" URL box appear at the bottom.
*   **Fail Conditions & Tracking Tab:**
    *   **Fail Conditions:** A list where you can add and remove failure conditions. **Tip:** You can also double-click an existing condition in the list to edit it directly.
    *   **Achievement Tracking:** Text boxes for the "Trigger Indicator" and "Measured Indicator" descriptions.
*   **Misc / Dev Notes Tab:** Two text boxes for adding the small, subscripted notes at the bottom of a guidance cell.

#### Writing Effective Guidance: Creating References
You'll often need to link to other achievements or external URLs within your guidance text. The tool makes this easy.

1.  Type your text (e.g., "See the Secondary Objective").
2.  Highlight the part you want to be a link (e.g., "Secondary Objective").
3.  Press **`Ctrl+K`** or right-click and choose **"Reference..."**.
4.  A dialog box will appear. Next, input the achievement ID. It will look like this `[Secondary Objective](#516066)`

<img width="1264" height="711" alt="Attach10" src="https://i.ibb.co/5gGKbRGG/Attach10.png" />

*"Create Reference Link" pop-up dialog.*

*   **To link to another achievement:** Enter just the achievement's ID (e.g., `516066`). The tool will generate `[Secondary Objective](#516066)`.
*   **To link to an external URL:** Paste the full URL (e.g., a YouTube or Dropbox link). The tool will generate `[▶️ Watch Video Walkthrough](https://...)`.

### Collectible Achievement Editor
*(Selected when an achievement is inside a category that has been manually marked as a "Collectible Category")*

This is a highly specialized editor for achievements that involve finding many items. It deconstructs the complex guidance into a manageable tree structure.

<img width="1264" height="711" alt="Attach11" src="https://i.ibb.co/FkbFx0BH/Attach11.png" />

*The Collectible Editor showing the "Certified Superhuman" achievement, with the tree of HP Upgrades on the left and the editor panels on the right.*

*   **Left Panel (Collectible Tree):** A dedicated `TreeView` for managing groups and items. You can add, delete, duplicate, and re-order items here.
*   **Right Panel (Editors):**
    *   **Group Editor:** A simple textbox for the group's title (e.g., "HP Upgrades").
    *   **Item Editor:** Fields for the item's description, URL, and URL text.
    *   **Introduction & Measured Indicator:** Text boxes for the text that appears before and after the list of collectibles.

When you finish editing, the tool automatically serializes this entire structure back into the complex, formatted Markdown required by the wiki template.

### Leaderboard Editor
*(Selected by clicking any 🥇 Leaderboard)*

<img width="1264" height="711" alt="Attach12" src="https://i.ibb.co/9k2XK9Cc/Attach12.png" />

*The Leaderboard Editor showing the "Time Trial" leaderboard.*

This editor provides a structured way to document leaderboards.
*   **Title:** The name of the leaderboard.
*   **Description Tab:** A rich text box for the main description.
*   **Conditions & Scoring Tab:** Four rich text boxes to detail the `Start`, `Cancel`, `Submit`, and `Measured Value` conditions. Each line in a box becomes a bullet point in the final guide.
*   **Misc / Dev Notes Tab:** For any additional notes.

### Credits Editor
*(Selected by clicking any 👤 Credit)*

This editor makes managing the credits section easy and consistent.

<img width="1264" height="711" alt="Attach13" src="https://i.ibb.co/Y75mCW24/Attach13.png" />

*Credits Editor showing ASolidSnack's entry, with the Contributor role selected and the RA-Guide Design sub-role checked.*

*   **User Details:** Fields for the username and avatar URL. The avatar will preview on the left.
*   **Contribution:**
    *   **Role:** A dropdown for the main role (e.g., "Achievement Set Developer," "Contributor").
    *   **Sub-Roles:** A checklist of optional sub-roles appears based on your main role selection. Checking them automatically appends them to the role string in the final Markdown (e.g., `*Contributor* | *Tester*`).
    *   **Contribution Details:** A rich text box for a bulleted list of their specific contributions.

## 5. Advanced Features

### Rich Text Formatting & Shortcuts
All rich text boxes support basic formatting shortcuts to speed up your workflow:
*   **`Ctrl+B`**: Toggle Bold
*   **`Ctrl+I`**: Toggle Italic
*   **`Ctrl+K`**: Insert Link/Reference
*   **`Ctrl+X` / `C` / `V`**: Cut / Copy / Paste
*   **`Ctrl+Z` / `Ctrl+Shift+Z`**: Undo / Redo (within the textbox)

### Undo & Redo System
The application has a global undo/redo system. Almost every action—from editing text and adding an item to moving a category—is recorded.
*   **`Edit > Undo` (`Ctrl+Z`)**: Reverts the last action.
*   **`Edit > Redo` (`Ctrl+Shift+Z`)**: Re-applies the last undone action.

> **Note:** The global undo is separate from the individual textbox undo. If you are typing, `Ctrl+Z` will undo your typing. If you click outside the textbox first, `Ctrl+Z` will undo the last major action (like deleting an achievement).

### Spell Checking
The tool includes a built-in spell checker (for English) to help catch typos.
*   **Enable/Disable:** Go to `Edit > Enable Spell Check`. A restart is required for the change to take full effect.
*   **Usage:** Misspelled words will be underlined in red. Right-click on a misspelled word to see suggestions at the top of the context menu.

## 6. Saving and Exporting

### Saving Your Project File
To save your work-in-progress, you should save the project file.
*   **`File > Save Project` (`Ctrl+S`)**: Saves the current state to a `.raguide` file.
*   **`File > Save Project As...`**: Saves the project to a new location.

Saving the project file allows you to close the application and pick up right where you left off, with all your structured data intact.

### Exporting the Final Markdown
When your guide is complete, it's time to generate the final output for the wiki.
1.  Go to `File > Export Markdown...` (`Ctrl+E`).
2.  Choose a name and location for your `.txt` file.

The application will handle all the heavy lifting. It will take your entire structured project and generate a single, perfectly formatted Markdown file, ready to be copied and pasted into the RetroAchievements wiki.