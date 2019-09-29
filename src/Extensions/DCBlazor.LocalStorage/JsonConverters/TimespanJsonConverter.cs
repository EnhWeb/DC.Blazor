using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DCBlazor.Storage.JsonConverters
{
    /// <summary>
    /// 新的Json.NET目前不支持Timespan
    /// </summary>
    public class TimespanJsonConverter : JsonConverter<TimeSpan>
    {
        /// <summary>
        /// 格式: 天.小时:分钟:秒:微秒
        /// </summary>
        public const string TimeSpanFormatString = @"d\.hh\:mm\:ss\:FFF";

        /// <summary>
        /// 读取并将JSON转换为T类型。
        /// </summary>
        /// <param name="reader">Json读取器</param>
        /// <param name="typeToConvert">要转换的类型</param>
        /// <param name="options">指定要使用的序列化选项的对象</param>
        /// <returns>转换后的值</returns>
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();
            if (string.IsNullOrWhiteSpace(s))
            {
                return TimeSpan.Zero;
            }

            TimeSpan parsedTimeSpan;
            if (!TimeSpan.TryParseExact(s, TimeSpanFormatString, null, out parsedTimeSpan))
            {
                throw new FormatException($"输入时间跨度不是预期的格式：预期的 {Regex.Unescape(TimeSpanFormatString)}. 请以字符串形式检索此键并手动解析.");
            }
            else
            {
                return parsedTimeSpan;
            }
        }

        /// <summary>
        /// 将指定值写入Json
        /// </summary>
        /// <param name="writer">Json写入器</param>
        /// <param name="value">要写入的对象</param>
        /// <param name="options">指定要使用的序列化选项的对象</param>
        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            var timespanFormatted = $"{value.ToString(TimeSpanFormatString)}";
            writer.WriteStringValue(timespanFormatted);
        }
    }
}
