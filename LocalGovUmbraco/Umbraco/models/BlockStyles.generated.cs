//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v12.3.3+d2ff2ea
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	// Mixin Content Type with alias "blockStyles"
	/// <summary>Block Styles</summary>
	public partial interface IBlockStyles : IPublishedElement
	{
		/// <summary>Custom CSS Classes</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string Classes { get; }

		/// <summary>Horizontal Alignment</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string HorizontalAlignment { get; }

		/// <summary>Vertical Alignment</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string VerticalAlignment { get; }
	}

	/// <summary>Block Styles</summary>
	[PublishedModel("blockStyles")]
	public partial class BlockStyles : PublishedElementModel, IBlockStyles
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		public new const string ModelTypeAlias = "blockStyles";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<BlockStyles, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public BlockStyles(IPublishedElement content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Custom CSS Classes
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("classes")]
		public virtual string Classes => GetClasses(this, _publishedValueFallback);

		/// <summary>Static getter for Custom CSS Classes</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetClasses(IBlockStyles that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "classes");

		///<summary>
		/// Horizontal Alignment
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("horizontalAlignment")]
		public virtual string HorizontalAlignment => GetHorizontalAlignment(this, _publishedValueFallback);

		/// <summary>Static getter for Horizontal Alignment</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetHorizontalAlignment(IBlockStyles that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "horizontalAlignment");

		///<summary>
		/// Vertical Alignment
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("verticalAlignment")]
		public virtual string VerticalAlignment => GetVerticalAlignment(this, _publishedValueFallback);

		/// <summary>Static getter for Vertical Alignment</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "12.3.3+d2ff2ea")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetVerticalAlignment(IBlockStyles that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "verticalAlignment");
	}
}
