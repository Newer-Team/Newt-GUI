using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct liq_color
{
    public byte R, G, B, A;
};

[StructLayout(LayoutKind.Sequential)]
public struct liq_palette
{
    public int Count;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public liq_color[] Entries;
};

enum liq_error
{
    LIQ_OK = 0,
    LIQ_QUALITY_TOO_LOW = 99,
    LIQ_VALUE_OUT_OF_RANGE = 100,
    LIQ_OUT_OF_MEMORY,
    LIQ_ABORTED,
    LIQ_BITMAP_NOT_AVAILABLE,
    LIQ_BUFFER_TOO_SMALL,
    LIQ_INVALID_POINTER,
};

namespace Newt.ImageQuant
{
    using liq_attr_ptr = IntPtr;
    using liq_image_ptr = IntPtr;
    using liq_result_ptr = IntPtr;
    using size_t = UIntPtr;

    class Liq
    {
        [DllImport(@"imagequant.dll")]
        public static extern liq_attr_ptr liq_attr_create();
        [DllImport(@"imagequant.dll")]
        public static extern liq_attr_ptr liq_attr_copy(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern void liq_attr_destroy(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_set_max_colors(liq_attr_ptr attr, int colors);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_max_colors(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_set_speed(liq_attr_ptr attr, int speed);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_speed(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_set_min_opacity(liq_attr_ptr attr, int min);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_min_opacity(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_set_min_posterization(liq_attr_ptr attr, int bits);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_min_posterization(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_set_quality(liq_attr_ptr attr, int minimum, int maximum);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_min_quality(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_max_quality(liq_attr_ptr attr);
        [DllImport(@"imagequant.dll")]
        public static extern void liq_set_last_index_transparent(liq_attr_ptr attr, int is_last);
        [DllImport(@"imagequant.dll")]
        public static extern liq_image_ptr liq_image_create_rgba(liq_attr_ptr attr, [In, MarshalAs(UnmanagedType.LPArray)] byte[] bitmap, int width, int height, double gamma);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_image_set_memory_ownership(liq_image_ptr image, int ownership_flags);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_image_add_fixed_color(liq_image_ptr img, liq_color color);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_image_get_width(liq_image_ptr img);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_image_get_height(liq_image_ptr img);
        [DllImport(@"imagequant.dll")]
        public static extern void liq_image_destroy(liq_image_ptr img);
        [DllImport(@"imagequant.dll")]
        public static extern liq_result_ptr liq_quantize_image(liq_attr_ptr attr, liq_image_ptr input_image);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_set_dithering_level(liq_result_ptr res, float dither_level);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_set_output_gamma(liq_result_ptr res, double gamma);
        [DllImport(@"imagequant.dll")]
        public static extern double liq_get_output_gamma(liq_result_ptr res);
        [DllImport(@"imagequant.dll")]
        public static extern IntPtr liq_get_palette(liq_result_ptr res);
        [DllImport(@"imagequant.dll")]
        public static extern liq_error liq_write_remapped_image(liq_result_ptr res, liq_image_ptr input_image, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer, size_t buffer_size);
        [DllImport(@"imagequant.dll")]
        public static extern double liq_get_quantization_error(liq_result_ptr res);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_quantization_quality(liq_result_ptr res);
        [DllImport(@"imagequant.dll")]
        public static extern double liq_get_remapping_error(liq_result_ptr res);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_get_remapping_quality(liq_result_ptr res);
        [DllImport(@"imagequant.dll")]
        public static extern void liq_result_destroy(liq_result_ptr res);
        [DllImport(@"imagequant.dll")]
        public static extern int liq_version();
    }
}