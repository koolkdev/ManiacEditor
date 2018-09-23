using System.Collections.Generic;
using RSDKv5;

namespace ManiacEditor
{
    /// <summary>
    /// Defines the horizontal scrolling behaviour of a set of potentially non-contiguous lines.
    /// </summary>
    public class HorizontalLayerScroll
    {
        private byte _id;
        private ScrollInfo _scrollInfo;
        private IList<ScrollInfoLines> _linesMapList;

        /// <summary>
        /// Creates a new scrolling behaviour rule, but not yet applied to any lines.
        /// </summary>
        /// <param name="id">Internal identifer to use for display purposes</param>
        /// <param name="info">The rules governing the scrolling behaviour</param>
        public HorizontalLayerScroll(byte id, ScrollInfo info) 
            : this(id, info, new List<ScrollInfoLines>())
        {
        }

        /// <summary>
        /// Creates a new scrolling behaviour rule, applied to the given map of lines.
        /// </summary>
        /// <param name="id">Internal identifer to use for display purposes</param>
        /// <param name="info">The rules governing the scrolling behaviour</param>
        /// <param name="linesMap">Set of line level mappings which define the lines the rules apply to</param>
        public HorizontalLayerScroll(byte id, ScrollInfo info, IList<ScrollInfoLines> linesMap)
        {
            _id = id;
            _scrollInfo = info;
            _linesMapList = linesMap;
        }

        /// <summary>
        /// Internal identifier.
        /// </summary>
        /// <remarks>This is NOT persisted to any RSDKv5 backing field!</remarks>
        public byte Id { get => _id; set => _id = value; }

        public byte UnknownByte1 { get => _scrollInfo.UnknownByte1; set => _scrollInfo.UnknownByte1 = value; }
        public byte UnknownByte2 { get => _scrollInfo.UnknownByte2; set => _scrollInfo.UnknownByte2 = value; }
        public short UnknownWord1 { get => _scrollInfo.UnknownWord1; set => _scrollInfo.UnknownWord1 = value; }
        public short UnknownWord2 { get => _scrollInfo.UnknownWord2; set => _scrollInfo.UnknownWord2 = value; }

        public IList<ScrollInfoLines> LinesMapList { get => _linesMapList; }
        public ScrollInfo ScrollInfo { get => _scrollInfo; }

        /// <summary>
        /// Applies the set of rules to the given set of lines.
        /// This may be called multiple times to set-up multiple mappings, 
        /// which need not be contiguous.
        /// </summary>
        /// <param name="startLine">The line at which these rules begin to apply (base 0)</param>
        /// <param name="lineCount">The number of contiguous lines to which the rules apply</param>
        public void AddMapping(int startLine, int lineCount)
        {
            _linesMapList.Add(new ScrollInfoLines(startLine, lineCount));
        }

        /// <summary>
        /// Creates an empty line level mapping which can be further manipulated
        /// </summary>
        public void AddMapping()
        {
            AddMapping(0, 0);
        }
    }
}
