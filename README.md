# Determined-Dialogue

Determined Dialogue
Version 0.1
Created in Unity 2018.3

UPDATE: I made a (really low-quality, sorry) companion video that goes through this walkthrough step-by-step, so if you think that’d help you (or if you get confused), check it out! https://youtu.be/Bm_WSsMTY_s

This is a dialogue system for Unity2D that I created based around the Undertale dialogue system. Not all the functionality is there yet (in fact, I have many more features that I want to add!), but with the semester coming up, I thought I would release a stable version with some documentation and see what people thought of it.

1. Startup and Import into Unity
There is an importable custom package as well as Determined Dialgoue’s Assets folder available on GitHub. If you don’t know how to use GitHub (I barely do myself), click the green “Clone or Download” button on the right side of the page and download a ZIP file. This will contain all the files that I have so lovingly created.

To add the package to your project, extract the ZIP file, then in Unity, click Assets -> Import Package -> Custom Package…, drill down to where your extracted Determined Dialogue folder, and open Determined-Dialogue.unitypackage. This will import all the scripts, objects, etc. that you need into your Unity project.

2. Set up the Dialogue System in your scene
Drag the following prefabs into your scene hierarchy (they’re in the appropriately-named “Prefabs” folder:
- Canvas
- DialogueSystem
If you don’t have one, right-click in your scene hierarchy and put in an Audio Source (Right-click → Audio → Audio Source).
Click on the DialogueSystem in your hierarchy. An inspector should appear.

In the inspector, you should see “Dialogue System (Script)” and a list underneath it containing things like Audio Source, Portrait, etc. Because you have followed these directions, you already have everything you need to fill in the DialogueSystem in your hierarchy! Huzzah! (Does anyone else think “hierarchy” should be spelled “heirarchy”... like, heirs…?)
With the inspector open, go back to your hierarchy and expand Canvas, then TextBox.
Drag the following from your hierarchy to the appropriate spot under Dialogue System (Script) in the inspector:


Inspector
Hierarchy
Audio Source
Audio Source
Portrait
Portrait (inside TextBox)
Text Box
TextBox
UI Text
TextMeshPro Text (inside Canvas)
There ya go! The DialogueSystem is now set up in your scene! (Maybe save at this point. Or before this point.)

3. Setting up an NPC
The Easy Way
Grab the NPC prefab from the “Prefabs” folder and drag it into your scene. It’s pretty lightweight, just has a sprite, a few BoxCollider2Ds, and an Interactable script with some sample dialogue attached. (Note: At this point, you can see the system function if you drag in the Player prefab and one (or more) NPC prefabs. Move the NPCs away from the Player in your scene, and you can run around using WASD to talk to beach balls!)

The Way to use if you already have NPCs or Whatever
Create an NPC however you normally do, or click on an existing one in the inspector. As long as both the player and NPC have a BoxCollider2D (and the NPC’s is set as a Trigger), the DialogueSystem should work.
Go to the Scripts folder and drag the Interactable script onto your NPC in the inspector. Congrats, your NPC is…. Well, it’s almost there. All we need to do is set up a dialogue for them and attach it.

4. Setting up a Dialogue for NPCs and Attaching It
Setting Up Dialogue
In your Assets Folder, click on the Dialogue Folder.
Right-Click in the right pane, then click Create → Dialogue → New Dialogue. You should see a new dialogue appear, just like you told it to. Name it whatever you’d like.
Click on your new dialogue and you should see it show up in the inspector.
Here’s a breakdown of what’s in the inspector (Note: Some of these fields are not yet used, but are built in for future features):
NPC ID: Not yet used
Sprite: Putting your NPC’s sprite in this field allows it to show up as a portrait in the TextBox. Put in any sprite that you’d like to show up when your NPC is talked to.
NPC Name: Not yet used, but naming your NPCs is fun and cute! I recommend it!
Sound: This is the sound that will play with every letter of dialogue that’s displayed. Drag an audio clip (preferably .ogg and 0.035 seconds long) into this field, and you can give your characters “voices”! (Eventually I’ll get around to making this optional)
Messages. This one is confusing, so I’m going to break it out into its own section.
Setting Up your Dialogue’s Messages
Okay, I’m going to level with you: there are a lot of Messages fields, and they can get a little confusing. But for now, what you need to know is that only a few of these are actually used; I put in more fields so building in future features will be easier.

Here are the fields that you need to know:
Size (the one right under Messages): This is the total number of dialogue pieces that your NPC has. For example, a size of 5 means that your NPC will say 5 different things. Let’s keep it simple and start with a size of 3 for your first dialogue.
As soon as you set your Messages Size, three elements pop up: Element 0, Element 1, and Element 2. Under each of these, we have a few fields:
Message Speed: Set your NPC to talk slowly, quickly, or medium-ly.
Text: The actual content that you want your NPC to say.
Responses: Only Responses Size 1 is currently supported. Eventually we’ll get into branching dialogue, we’re just not there yet. See below.
Setting Up your Dialogue’s Responses
This is the most confusing part. If you get this, you’re pretty much home free.
Under the “Responses” section of Element 0, Element 1, and Element 2, you’ll see a “Size” field. Set all of these to 1. You’ll see a bunch of fields pop up. For the moment, the only one you have to worry about is the “Next” field.
The “Next” field points one piece of dialogue to the next. So, under your first response, you want to point Message “Element 0” to Message “Element 1”. So, fo your first “Next” field, type 1.
Under Message Element 1’s “Responses” field, set “Next” to -1. Setting a “Next” to -1 makes the NPC stop talking. It’ll keep yammering on forever (or throw an error) if you don’t set a “Next” to -1, so do it, please.
“But what about Message Element 2?” you may be asking yourself. Great question! Element 2 is for that “bonus dialogue” you get for talking to someone a second time. (Does everyone love that as much as I do? Because I LOVE IT.)
Set Element 2’s message text to whatever you’d like, then set that Next to -1 as well. If all goes according to plan, the first time you talk to the NPC, it will “speak” the text from Message Elements 0 and 1, then stop talking (the text box will disappear, etc). Then, if you talk to the NPC again, it’ll “speak” the text from Element 2!! Neat, huh?!

5. Tying it all together
Remember that Interactable script you dragged onto your NPC in Step 3? If you click on your NPC and see the Interactable script in the inspector, you’ll notice that there’s a Dialogue field in that script. Drag the Dialogue that you lovingly created in the previous step onto the Interactable script.

If you did everything you needed to do with your Dialogue, DialogueSystem, and NPC, you should be able to walk up to your NPCs and talk to them by pressing Space!

wahoo!
