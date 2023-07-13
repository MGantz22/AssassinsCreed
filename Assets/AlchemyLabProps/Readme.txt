Imported assets will be placed in "Multistory Dungeons 2" folder.

Which version to choose?

For Built-in workflow:

1) Check your color space settings under Edit -> Project Settings -> Player -> Other Settings.

2) Pick a version that matches your workflow and color space.

For example, if you don't use an SRP and your color space is Linear, then
AlchemyLabProps_Built-in_Linear_2018.4.unitypackage is for you.

3) Double Click on a pack to import its contents.
Or go to Assets -> Import Package -> Custom Package and select the one you want to import.

For SRP:

1) These should always be in linear color space (Edit -> Project Settings -> Player -> Other Settings)

2) Install High Definition RP or Universal RP from the Package Manager (Window -> Package Manager),
then create and assign a RenderPipelineAsset to a corresponding field under
Edit -> Project Settings -> Graphics.

3) Double Click on a pack to import its contents.
Or go to Assets -> Import Package -> Custom Package and select the one you want to import.

The pack is set up to work with lightmap resolution of 8 and above.

LINKS:

Complete Multistory Dungeons pack can be found here:
https://assetstore.unity.com/packages/3d/environments/dungeons/multistory-dungeons-33955

You can learn more about SRP here: https://unity.com/srp
