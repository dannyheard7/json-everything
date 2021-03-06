# [1.7.0](https://github.com/gregsdennis/json-everything/pull/65)

- Updated hard-coded 2020-12 meta-schemas to match the published documents.
- Added the following `JsonSchemaBuilder` extension method overloads:
  - `.DynamicRef(string)`
  - `.Const(JsonElementProxy)`
  - `.Default(JsonElementProxy)`
  - `.Enum(IEnumerable<JsonElementProxy>)`
  - `.Enum(params JsonElementProxy[])`
  - `.Examples(IEnumerable<JsonElement>)`
  - `.Examples(IEnumerable<JsonElementProxy>)`
  - `.Examples(params JsonElementProxy[])`
  
(See [Json.More.Net v1.3.0](json-more.md) for more information on `JsonElementProxy`.)

# [1.6.1](https://github.com/gregsdennis/json-everything/pull/61)

Signed the DLL for strong name compatibility.

# [1.6.0](https://github.com/gregsdennis/json-everything/pull/52)

Added support for Draft 2020-12.

- Meta-schema validation now always occurs superficially in that it validates that the meta-schema is known.  The `ValidationOptions.ValidateMetaSchema` option now only controls whether a full meta-schema validation of the schema will occur.  This should only affect clients validating schemas declaring custom meta-schemas with the `$schema` keyword.  Custom meta-schemas will now need to be loaded into the system manually or `SchemaRegistry.Fetch` will need to be set to retrieve it automatically.
- Added all new vocabularies and meta-schemas.
- New keywords:
  - `$dynamicRef` - replaces/augments `$recursiveRef`
  - `$dynamicAnchor` - replaces/augments `$recursivAnchor`
  - `prefixItems` - replaces array-form `items`
- Added `JsonSchemaBuilder` extension method for `$anchor` which should have been added for draft 2019-09 support.
- `ValidationOptions.ValidateFormat` has been obsoleted and replaced by `ValidationOptions.RequireFormatValidation` with the same semantics and default.
- `FormatKeyword` now responds to the presence of the format vocabularies in the meta-schema declared by the `$schema` keyword as well as the `ValidationOptions.RequireFormatValidation` option.  (Includes a bug fix for draft 2019-09 schemas that use a meta-schema that declare the format vocabulary with a value of `true`.)

# [1.5.4](https://github.com/gregsdennis/json-everything/pull/45)

Added debug symbols to package.  No functional change.

# [1.5.3](https://github.com/gregsdennis/json-everything/pull/41)

Fixed `NullReferenceException` when comparing two schemas.

# [1.5.2](https://github.com/gregsdennis/json-everything/pull/40)

Updated wording for `enum` error message.  This must remain generic and cannot include the expected values because the list could be long and the values could be quite large.

# [1.5.1](https://github.com/gregsdennis/json-everything/pull/34)

[#35](https://github.com/gregsdennis/json-everything/issues/35) `JsonSchema.FromFile()` handles file paths as URIs incorrectly in non-Windows systems. 

# [1.5.0](https://github.com/gregsdennis/json-everything/pull/34)

[#33](https://github.com/gregsdennis/json-everything/issues/33) Added `ValidationOptions.ValidateFormat` which allows configuration of whether to validate the `format` keyword.  Also fixes a bug where the `format` keyword was validated by default for draft 2019-09 which specifies that it should only generate annotations by default.  Because this library favors the latest draft, this is the default behavior for all drafts.

As a further followup to #27 (below), basic output has been refined.

# [1.4.0](https://github.com/gregsdennis/json-everything/pull/31)

[#27](https://github.com/gregsdennis/json-everything/issues/27) (reopened) Better reduction of detailed output format which eliminates the notion that any nodes *must* be kept.

[#29](https://github.com/gregsdennis/json-everything/issues/29) Relative `$id` keyword at root of schema was not supported.  Added `ValidationOptions.DefaultBaseUri` to be used when no other absolute URI is defined by the `$id` keyword.  Also now supports assuming the base URI from the file name.

# [1.3.1](https://github.com/gregsdennis/json-everything/pull/28)

[#27](https://github.com/gregsdennis/json-everything/issues/27) Nodes in the basic and detailed output formats that match the overall outcome should be removed.  This also addresses several other bugs involving the output such as `absoluteKeywordLocation`.

# [1.3.0](https://github.com/gregsdennis/json-everything/pull/25)

[#15](https://github.com/gregsdennis/json-everything/issues/15) Easier navigation of the schema and its subschemas. Added `ISchemaContainer`, `ISchemaCollector`, and `IKeyedSchemaCollector` for the varying sets of subschemas that keywords can have.  Added `SchemaKeywordExtensions.GetSubschemas()` extension method.

[#19](https://github.com/gregsdennis/json-everything/issues/19) Keyword filtering doesn't consider declared draft or `ValidationOptions.ValidateAs`.

# [1.2.0](https://github.com/gregsdennis/json-everything/pull/17)

([json-schema<nsp>.org #358](https://github.com/json-schema-org/json-schema-org.github.io/pull/358)) Published draft 06 meta-schema doesn't match the copy in the spec repo.

[#16](https://github.com/gregsdennis/json-everything/issues/16) `JsonSchema` equality checking.  Along with this, added `IEquatable<T>` to `SchemaKeywordRegistry.Register<T>()`.

[#18](https://github.com/gregsdennis/json-everything/issues/18) `properties` keyword is processed with same priority as `additionalProperties` making keyword order important, but it shouldn't be.

Added `EnumerableExtensions.ContentsEqual()`.

# [1.1.0](https://github.com/gregsdennis/json-everything/pull/11)

Added `SchemaRegistry.Fetch` property to enable automatic downloading of referenced schemas.

# [1.0.3](https://github.com/gregsdennis/json-everything/pull/11)

[#9](https://github.com/gregsdennis/json-everything/pull/11) `if`/`then`/`else` are processed in serialized order instead of processing `if` first.

[#10](https://github.com/gregsdennis/json-everything/pull/10) Bug fix around deserialization of `readonly` keyword.

# [1.0.2](https://github.com/gregsdennis/json-everything/pull/7)

Updated format `json-pointer` to require plain pointers.  URI-encoded pointers are invalid.

# [1.0.1](https://github.com/gregsdennis/json-everything/pull/6)

Updated validation of formats `hostname`, `iri`, `uri`, `regex`, and `time`.

Fixed issue resolving references (`$ref` & `$recursiveRef`) to miscellaneous (non-keyword) schema data.

# 1.0.0

Initial release.