﻿using System;
using System.Text.Json;
using Json.More;

namespace Json.Path.QueryExpressions
{
	internal class LessThanOrEqualToOperator : IQueryExpressionOperator
	{
		public int OrderOfOperation => 4;

		public QueryExpressionType GetOutputType(QueryExpressionNode left, QueryExpressionNode right)
		{
			if (left.OutputType != right.OutputType) return QueryExpressionType.Invalid;
			return left.OutputType switch
			{
				QueryExpressionType.Number => QueryExpressionType.Boolean,
				QueryExpressionType.String => QueryExpressionType.Boolean,
				_ => QueryExpressionType.Invalid
			};
		}

		public JsonElement Evaluate(QueryExpressionNode left, QueryExpressionNode right, JsonElement element)
		{
			var lElement = left.Evaluate(element);
			var rElement = right.Evaluate(element);
			switch (lElement.ValueKind)
			{
				case JsonValueKind.Number:
					if (lElement.ValueKind != JsonValueKind.Number ||
					    rElement.ValueKind != JsonValueKind.Number) return default;
					return (lElement.GetDecimal() <= rElement.GetDecimal()).AsJsonElement();
				case JsonValueKind.String:
					if (lElement.ValueKind != JsonValueKind.String ||
					    rElement.ValueKind != JsonValueKind.String) return default;
					return (string.Compare(lElement.GetString(), rElement.GetString(), StringComparison.Ordinal) <= 0).AsJsonElement();
				default:
					return default;
			}
		}

		public string ToString(QueryExpressionNode left, QueryExpressionNode right)
		{
			return $"{left}<={right}";
		}
	}
}