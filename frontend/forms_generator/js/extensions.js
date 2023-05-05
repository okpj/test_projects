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
  return htmlElement;
}

function createButtonHTMLElement(element) {
  let htmlElement = document.createElement(buttonTagName);
  htmlElement.innerText = element.text;
  htmlElement.className = element.class;
  return htmlElement;
}

function createTextHTMLElement(element) {
  let labelHTMLElement = createLabelHTMLElement(element);

  const elementType = element.type == ElementType.textarea ? textareaTagName : inputTagName;
  let htmlElement = document.createElement(elementType);
  htmlElement.value = element.value;
  htmlElement.placeholder = element.placeholder;
  setBaseElementAttributes(htmlElement, element);

  labelHTMLElement.appendChild(htmlElement);
  return labelHTMLElement;
}

function createSelectHTMLElement(element) {
  let labelHTMLElement = createLabelHTMLElement(element);

  let htmlElement = document.createElement(selectTagName);
  element.options.forEach((option) => {
    htmlElement.appendChild(option.toHTMLElement());
  });

  setBaseElementAttributes(htmlElement, element);
  labelHTMLElement.appendChild(htmlElement);
  return labelHTMLElement;
}

function createRadioHTMLElement(element) {
  let fieldSetHTMLElement = createFieldsetHTMLElement(element.class);

  element.items.forEach((item) => {
    let labelHTMLElement = createLabelHTMLElement(item);
    let htmlElement = item.toHTMLElement();
    labelHTMLElement.insertBefore(htmlElement, labelHTMLElement.firstChild);

    setBaseElementAttributes(htmlElement, element);
    fieldSetHTMLElement.appendChild(labelHTMLElement);
  });

  return fieldSetHTMLElement;
}

function createCheckboxHTMLElement(element) {
  let fieldSetHTMLElement = createFieldsetHTMLElement();
  let labelHTMLElement = createLabelHTMLElement(element);
  fieldSetHTMLElement.appendChild(labelHTMLElement);

  let htmlElement = document.createElement(inputTagName);
  htmlElement.checked = element.checked;

  setBaseElementAttributes(htmlElement, element);
  labelHTMLElement.appendChild(htmlElement);

  return fieldSetHTMLElement;
}

function setBaseElementAttributes(htmlElement, element) {
  htmlElement.name = element.name;
  htmlElement.required = element.required;
  htmlElement.type = element.validationRules.type;
  if (element.validationRules.type == ValidationRuleType.tel) {
    htmlElement.pattern = phoneRegex;
  }
  htmlElement.disabled = element.disabled;
}

function createLabelHTMLElement(element) {
  let labelHTMLElement = document.createElement(labelTagName);
  if (element.class) {
    labelHTMLElement.className = element.class;
  }

  let spanHTMLElement = document.createElement(spanTagName);
  spanHTMLElement.innerText = element.label;

  labelHTMLElement.appendChild(spanHTMLElement);
  return labelHTMLElement;
}

function createFieldsetHTMLElement(className) {
  let fieldSetHTMLElement = document.createElement(fieldsetTagName);
  if (className) {
    fieldSetHTMLElement.className = className;
  }
  return fieldSetHTMLElement;
}
