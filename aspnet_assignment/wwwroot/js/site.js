const selectedOption = document.querySelector('#select-option');
const addCategoryBtn = document.querySelector('#add-category-btn');
const selectedCategories = document.querySelector('#selected-categories');
const removeCategory = document.querySelector('#remove-category-btn');


addCategoryBtn.addEventListener('click', () => {

    const el = document.createElement('span');
    const value = selectedOption.value;

    el.innerHTML = `<span  id="selected-category" class="me-3">${value}</span>`;

    selectedCategories.appendChild(el);

});


removeCategory.addEventListener('click', () => {

    const el = document.querySelector('#selected-category')

    selectedCategories.remove(el);
});


