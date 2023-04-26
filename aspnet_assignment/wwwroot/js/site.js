const addButton = document.querySelector("#add-more-button");
const imageDiv = document.querySelector("#image-div");

let inputCount = 0;

addButton.addEventListener('click', () => {
    inputCount++;

    const newInput = document.createElement('input');
    newInput.type = 'text';
    newInput.name = `asp-for${inputCount}`
    newInput.className = `mb-3 form-control`;

    imageDiv.appendChild(newInput)
})

