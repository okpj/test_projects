const filterTagName = "div";
const buttonTagName = "button";
const textareaTagName = "textarea";
const inputTagName = "input";
const labelTagName = "label";
const optionTagName = "option";
const selectTagName = "select";
const fieldsetTagName = "fieldset";

Form.prototype.toHTMLElement = function () {
  let htmlForm = document.createElement("form");
  htmlForm.name = this.name;
  htmlForm.className = "form";
  this.items.forEach((element) => {
    let htmlElement = element.toHTMLElement();
    htmlForm.appendChild(htmlElement);
  });
  return htmlForm;
};

Item.prototype.toHTMLElement = function () {
  switch (this.type) {
    case ElementType.filler:
      return createFilterHTMLElement(this);
    case ElementType.button:
      return createButtonHTMLElement(this);
    case ElementType.text:
    case ElementType.textarea:
      return createTextHTMLElement(this);
    case ElementType.checkbox:
      return createCheckboxHTMLElement(this);
    case ElementType.select:
      return createSelectHTMLElement(this);
    case ElementType.radio:
      return createRadioHTMLElement(this);
    default:
  }
};

SelectOption.prototype.toHTMLElement = function () {
  let optionHTMLElement = document.createElement(optionTagName);
  optionHTMLElement.value = this.value;
  optionHTMLElement.innerText = this.text;
  optionHTMLElement.selected = this.selected;
  return optionHTMLElement;
};

RadioItem.prototype.toHTMLElement = function () {
  let radioHtmlElement = document.createElement(inputTagName);
  radioHtmlElement.value = this.value;
  radioHtmlElement.checked = this.checked;
  return radioHtmlElement;
};

function createFilterHTMLElement(element) {
  let htmlElement = document.createElement(filterTagName);
  htmlElement.innerHTML = element.message;
  htmlElement.className = ElementType.filler;
  return htmlElement;
}

function createButtonHTMLElement(element) {
  let htmlElement = document.createElement(buttonTagName);
  htmlElement.innerText = element.text;
  htmlElement.className = element.class;
  return htmlElement;
}

function createTextHTMLElement(element) {
  let labelHTMLElement = createLabelHTMLElement(element.label);

  const elementType = element.type == ElementType.textarea ? textareaTagName : inputTagName;
  let htmlElement = document.createElement(elementType);
  htmlElement.value = element.value;
  htmlElement.placeholder = element.placeholder;
  setBaseElementAttributes(htmlElement, element);

  labelHTMLElement.appendChild(htmlElement);
  return labelHTMLElement;
}

function createCheckboxHTMLElement(element) {
  let labelHTMLElement = createLabelHTMLElement(element.label);

  let htmlElement = document.createElement(inputTagName);
  htmlElement.checked = element.checked;

  setBaseElementAttributes(htmlElement, element);
  labelHTMLElement.appendChild(htmlElement);
  return labelHTMLElement;
}

function createSelectHTMLElement(element) {
  let labelHTMLElement = createLabelHTMLElement(element.label);

  let htmlElement = document.createElement(selectTagName);
  element.options.forEach((option) => {
    htmlElement.appendChild(option.toHTMLElement());
  });

  setBaseElementAttributes(htmlElement, element);
  labelHTMLElement.appendChild(htmlElement);
  return labelHTMLElement;
}

function createRadioHTMLElement(element) {
  let fieldSetHTMLElement = createFieldsetHTMLElement();

  element.items.forEach((item) => {
    let labelHTMLElement = createLabelHTMLElement(item.label);
    let htmlElement = item.toHTMLElement();
    labelHTMLElement.appendChild(htmlElement);

    setBaseElementAttributes(htmlElement, element);
    fieldSetHTMLElement.appendChild(labelHTMLElement);
  });

  return fieldSetHTMLElement;
}

function setBaseElementAttributes(htmlElement, element) {
  htmlElement.name = element.name;
  htmlElement.required = element.required;
  htmlElement.type = element.validationRules.type;
  htmlElement.className = element.class;
  htmlElement.disabled = element.disabled;
}

function createLabelHTMLElement(text) {
  let labelHTMLElement = document.createElement(labelTagName);
  labelHTMLElement.innerText = text;
  return labelHTMLElement;
}

function createFieldsetHTMLElement() {
  let fieldSetHTMLElement = document.createElement(fieldsetTagName);
  return fieldSetHTMLElement;
}
