using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newt.ObjectClasses;

namespace Newt
{
    public static class Globals
    {
        public static Tileset EditedTileset = new Tileset();

        public static string[] BehaviourFlags = new string[]
                                                {
                                                    "Solid",
                                                    "**Coin",
                                                    "**Question Block",
                                                    "**Explodable Block",
                                                    "**Brick Block",
                                                    "**Slope",
                                                    "**Flipped Slope",
                                                    "Unknown (0x80)",
                                                    "**Entrance",
                                                    "Water",
                                                    "**Climbable",
                                                    "**Partial Solid",
                                                    "**Harmful Tile",
                                                    "Invisible Block",
                                                    "Unknown(0x4000)",
                                                    "Solid on Top",
                                                    "Solid on Bottom",
                                                    "**Donut Lift",
                                                    "Unknown(0x40000)",
                                                    "Unknown(0x80000)",
                                                };

        public static string[] TileSubtypes = new string[]
                                                {
                                                    "Normal",
                                                    "Ice",
                                                    "Snow",
                                                    "Quicksand",
                                                    "**Conveyor Right",
                                                    "**Conveyor Left",
                                                    "Horizontal Rope",
                                                    "Sideways Spikes or Collapsible Stairs",
                                                    "Unknown(8)",
                                                    "Ledge",
                                                    "Vertical Pole",
                                                    "No Sliding(for Slopes)",
                                                    "Unknown(12)",
                                                    "Slows you down",
                                                    "Sandy",
                                                    "Unknown(15)",
                                                };

        public static string[] GenericTileParams = new string[]
                                                    {
                                                        "0=Normal",
                                                        "1=Path from Bottom Left to Top Right",
                                                        "2=Path from Top Left to Bottom Right",
                                                        "3=Path corner for Top Left",
                                                        "4=Path corner for Bottom Right",
                                                        "5=Horizontal path",
                                                        "6=Vertical path",
                                                        "8=2x1 Path from Bottom Left to Top Right (leftmost)",
                                                        "9=2x1 Path from Bottom Left to Top Right (rightmost)",
                                                        "0xA=2x1 Path from Top Left to Bottom Right (leftmost)",
                                                        "0xB=2x1 Path from Top Left to Bottom Right (rightmost)",
                                                        "0xC=1x2 Path from Bottom Left to Top Right (topmost)",
                                                        "0xD=1x2 Path from Bottom Left to Top Right (bottommost)",
                                                        "0xE=1x2 Path from Top Left to Bottom Right (bottommost)",
                                                        "0xF=1x2 Path from Top Left to Bottom Right (topmost)",
                                                        "0x10=1x1 Circle Path",
                                                        "0x11=2x2 Circle Path Top Left",
                                                        "0x12=2x2 Circle Path Top Right",
                                                        "0x13=2x2 Circle Path Bottom Left",
                                                        "0x14=2x2 Circle Path Bottom Right",
                                                        "0x15=4x4 Circle Path Top Left Corner",
                                                        "0x16=4x4 Circle Path Top Middle (left)",
                                                        "0x17=4x4 Circle Path Top Middle (right)",
                                                        "0x18=4x4 Circle Path Top Right Corner",
                                                        "0x19=4x4 Circle Path Left Middle (top)",
                                                        "0x1A=4x4 Circle Path Right Middle (top)",
                                                        "0x1B=4x4 Circle Path Left Middle (bottom)",
                                                        "0x1C=4x4 Circle Path Right Middle (bottom)",
                                                        "0x1D=4x4 Circle Path Bottom Left Corner",
                                                        "0x1E=4x4 Circle Path Bottom Middle (left)",
                                                        "0x1F=4x4 Circle Path Bottom Middle (right)",
                                                        "0x20=4x4 Circle Path Bottom Right Corner",
                                                        "0x22=Path Stopper (Reverse Direction)",
                                                        "0x23=Vine Stopper",
                                                        "0x28=Coin Outline 1",
                                                        "0x29=Coin Outline 2"
                                                    };

        public static string[] CoinParams = new string[]
                                            {
                                                "0=Normal",
                                                "2=Unknown (2)",
                                                "4=Unknown (4)"
                                            };

        public static string[] QuestionBlockParams = new string[]
                                                    {
                                                        "0=Mushroom or Flower",
                                                        "1=Starman",
                                                        "2=Continuous Starman",
                                                        "3=1-up Mushroom",
                                                        "4=Springboard",
                                                        "5=Mini Mushroom",
                                                        "6=5 Floating Coins",
                                                        "7=Coin",
                                                        "8=Vine",
                                                        "9=Mushroom (param 9)",
                                                        "10=Mushroom (param 10)",
                                                        "11=Unknown (param 11)",
                                                        "12=Boo",
                                                        "13=Mega Mushroom",
                                                        "14=Unknown (14)",
                                                        "15=Unknown (15)",
                                                        "0x10=Thrown Mushroom or Flower",
                                                        "0x11=Thrown Coin",
                                                        "0x30=Invis. Mushroom or Flower",
                                                        "0x31=Invis. Starman",
                                                        "0x32=Invis. 1-up Mushroom",
                                                        "0x33=Invis. Coin",
                                                        "0x34=Invis. Vine",
                                                        "0x35=Invis. Mushroom",
                                                        "0x36=Invis. Unknown (0x36)",
                                                        "0x37=Invis. Unknown (0x37)"
                                                    };

        public static string[] BrickBlockParams = new string[]
                                                {
                                                    "0=Empty",
                                                    "1=Mushroom or Flower",
                                                    "2=Starman",
                                                    "3=1-up Mushroom",
                                                    "4=Coin",
                                                    "5=Multiple Coins",
                                                    "6=Vine",
                                                    "7=Empty (param 7)",
                                                    "8=Empty (param 8)",
                                                    "0x35=Blue Shell"
                                                };

        public static string[] ExplodableBlockParams = new string[]
                                                {
                                                    "0=Explodes into Used Block",
                                                    "1=Explodes into Stone Block",
                                                    "2=Explodes into Wooden Block",
                                                    "3=Explodes into Red Block"
                                                };

        public static string[] HarmfulTileParams = new string[]
                                                {
                                                    "0=Spikes facing Left",
                                                    "1=Spikes facing Right",
                                                    "2=Spikes facing Up",
                                                    "3=Spikes facing Down",
                                                    "4=Lava (instant death)",
                                                    "5=Instant Death",
                                                    "7=Harmful on all sides"
                                                };

        public static string[] ConveyorParams = new string[]
                                                {
                                                    "0=Slow",
                                                    "1=Fast"
                                                };

        public static string[] PipeDoorType = new string[]
                                                {
                                                    "Door or Breakable Green Pipe",
                                                    "Unbreakable Green Pipe",
                                                    "Breakable Red Pipe",
                                                    "Unbreakable Red Pipe",
                                                    "Breakable Yellow Pipe",
                                                    "Unbreakable Yellow Pipe",
                                                    "Unknown/Invalid Type 6",
                                                    "Unknown/Invalid Type 7"
                                                };

        public static string[] PipeDoorParams = new string[]
                                                {
                                                    "0=Up-facing: left side /OR/ Bottom left door",
                                                    "1=Up-facing: right side /OR/ Bottom right door",
                                                    "2=Down-facing: left side /OR/ Mini-Mario door",
                                                    "3=Down-facing: right side /OR/ Boss door bottom left",
                                                    "4=Vertical pipe: left side /OR/ Boss door bottom centre",
                                                    "5=Vertical pipe: right side /OR/ Boss door bottom right",
                                                    "6=Vert. over horz. junction: left side",
                                                    "7=Vert. over horz. junction: right side",
                                                    "8=Left-facing: top side",
                                                    "9=Left-facing: bottom side",
                                                    "0xA=Right-facing: top side",
                                                    "0xB=Right-facing: bottom side",
                                                    "0xC=Horizontal pipe: top side",
                                                    "0xD=Horizontal pipe: bottom side",
                                                    "0xE=Horz. over vert. junction: top side",
                                                    "0xF=Horz. over vert. junction: bottom side",
                                                    "0x10=Mini pipe top",
                                                    "0x11=Cracked vertical top: left side",
                                                    "0x12=Mini pipe bottom",
                                                    "0x13=Cracked vertical top: right side",
                                                    "0x15=Cracked vertical bottom: left side",
                                                    "0x16=Mini vert. over horz. junction",
                                                    "0x17=Cracked vertical bottom: right side",
                                                    "0x18=Mini pipe left",
                                                    "0x19=Cracked mini pipe bottom",
                                                    "0x1A=Mini pipe right",
                                                    "0x1B=Cracked mini pipe top",
                                                    "0x1C=Mini vertical pipe",
                                                    "0x1D=Mini horizontal pipe",
                                                    "0x1E=Mini horz. over vert. junction",
                                                    "0x1F=Pipe joint"
                                                };

        public static string[] DonutLiftParams = new string[]
                                                {
                                                    "0=Donut lift",
                                                    "1=Beach platform: left side",
                                                    "2=Beach platform: right side"
                                                };

        public static string[] SlopeParams = new string[]
                                                {
                                                    "0=1x1 Up-Right",
                                                    "1=1x1 Down-Right",
                                                    "2=2x1 Up-Right: leftmost part",
                                                    "3=2x1 Up-Right: rightmost part",
                                                    "4=2x1 Down-Right: leftmost part",
                                                    "5=2x1 Down-Right: rightmost part",
                                                    "6=1x2 Up-Right: bottom part",
                                                    "7=1x2 Up-Right: top part",
                                                    "8=1x2 Down-Right: bottom part",
                                                    "9=1x2 Down-Right: top part",
                                                    "10=Edge: Use directly under all slopes",
                                                    "11=4x1 Up-Right: part one",
                                                    "12=4x1 Up-Right: part two",
                                                    "13=4x1 Up-Right: part three",
                                                    "14=4x1 Up-Right: part four",
                                                    "15=4x1 Down-Right: part one",
                                                    "16=4x1 Down-Right: part two",
                                                    "17=4x1 Down-Right: part three",
                                                    "18=4x1 Down-Right: part four"
                                                };

        public static string[] FenceParams = new string[]
                                                {
                                                    "0=Vine",
                                                    "1=Unknown (1)",
                                                    "2=Fence: Top Left",
                                                    "3=Fence: Top",
                                                    "4=Fence: Top Right",
                                                    "5=Fence: Left",
                                                    "6=Fence: Centre",
                                                    "7=Fence: Right",
                                                    "8=Fence: Bottom Left",
                                                    "9=Fence: Bottom",
                                                    "10=Fence: Bottom Right",
                                                    "11=Flip Fence: Top Left",
                                                    "12=Flip Fence: Top",
                                                    "13=Flip Fence: Top Right",
                                                    "14=Flip Fence: Left",
                                                    "15=Flip Fence: Centre",
                                                    "16=Flip Fence: Right",
                                                    "17=Flip Fence: Bottom Left",
                                                    "18=Flip Fence: Bottom",
                                                    "19=Flip Fence: Bottom Right"
                                                };

        public enum ParamTypes
        {
            GenericTileParams,
            CoinParams,
            QuestionBlockParams,
            ExplodableBlockParams,
            BrickBlockParams,
            SlopeParams,
            PipeDoorParams,
            FenceParams,
            PartialBlockParams,
            HarmfulTileParams,
            DonutLiftParams,
            ConveyorParams,
            DummyUnsetParams,
        }

        public static string Python = "";
    }
}
