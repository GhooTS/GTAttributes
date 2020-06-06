# GTAttributes
Custom attributes for unity

### GT_Tag
Creates a tag field from a string variable

### GT_MinMax
Creates two slider and makes sure that the value in min slider is not larger than the value in max slider (second field should have HideInInspector attribute)
#### Constructor arguments
* min - minimum value
* max - maximum value
* name - name describing sliders 

### GT_MulitProperty
Align two or more fields horizontally (after first field, every next should have hideInInspector attribute)
#### Constructor arguments
* propertiesCount - number of variable to align (two by default)

### GT_ReadOnly
Displays field value as uneditable text

### GT_PredefineValue
Create a dropdown with values specified in constructor
#### Constructor arguments
* values - string values to display in dropdown

### GT_QucikView
Adds button that let u inspect any reference component in separate window without need to switch selection target, I find it especially useful with ScriptableObject.

### GT_ReferenceInjector
Creates a dropdown with list of types that inherit from specified interface or abstract class (SerializeReference attribute is required)
#### Drop down on the left:
* Refresh - refresh list of types
* Inject - inject selected type in the drop down (undo is not supported)

### GT_DisableGroupBegin
* If not argument specified field direcly below attribute will be disable in inspector, to disable every field in class you need to specified **GT_DisableGroupEnd** or **GT_DisableGroupEndDecorator** attribute for next field.
* If field name specified, then the field with that name will control whether fields between **GT_DisableGroupBegin** and **GT_DisableGroupEnd** (or **GT_DisableGroupEndDecorator**) are disabled or not.
#### Constructor arguments
* fieldName - name of the field that control whether fields between **GT_DisableGroupBegin** and **GT_DisableGroupEnd** (or **GT_DisableGroupEnd Decorator**) are disabled or not (work for reference type and bool)
* inverted - inverts disable group behaviour
* parentFieldName - field name of the parent disable group
* parentInverted - is parent disable group behaviour inverted?

### GT_DisableGroupEnd and GT_DisableGroupEndDecorator 
Ends disable group. Use **GT_DisableGroupEnd** for classes and **GT_DisableGroupEndDecorator** for fields


