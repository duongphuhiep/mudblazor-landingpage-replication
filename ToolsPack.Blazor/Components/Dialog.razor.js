/**
 * @param {HTMLDialogElement} element
 * @param {HTMLElement|undefined} focusElement
 */
export function showModal(element, focusElement = undefined) {
    if (!element) {
        console.warn('unable to showModal on non-exist element');
        return;
    }
    //console.info('showModal begin', element, focusElement);
    element.showModal();
    focus(focusElement, 300);
}

/**
 * @param {HTMLDialogElement} element
 * @param {HTMLElement|undefined} focusElement
 */
export function show(element, focusElement = undefined) {
    if (!element) {
        console.warn('unable to show on non-exist element');
        return;
    }
    element.show();
    focus(focusElement, 300);
}

/**
 * @param {HTMLDialogElement} element
 * @param {string} returnValue
 */
export function close(element, returnValue) {
    if (!element) {
        console.warn('unable to close on non-exist element');
        return;
    }
    element.close(returnValue);
}

/**
 * @param {HTMLDialogElement} element
 */
export function click(element) {
    if (!element) {
        console.warn('unable to click on non-exist element');
        return;
    }
    element.click();
}

/**
 * @param {HTMLDialogElement} element
 */
export function hidePopover(element) {
    if (!element) {
        console.warn('unable to hidePopover on non-exist element');
        return;
    }
    element.hidePopover();
}

/**
 * @param {HTMLDialogElement} element
 */
export function showPopover(element) {
    if (!element) {
        console.warn('unable to showPopover on non-exist element');
        return;
    }
    element.showPopover();
}

/**
 * @param {HTMLDialogElement} element
 * @param {boolean|undefined} force
 * @returns {boolean|undefined}
 */
export function togglePopover(element, force) {
    if (!element) {
        console.warn('unable to showModal on non-exist element');
        return;
    }
    return element.togglePopover(force)
}

/**
 * @param {HTMLElement} element
 * @param {number|undefined} delay
 */
function focus(element, delay = undefined) {
    if (!element) {
        return;
    }
    //console.info('focus begin', element);
    if (!delay) {
        element.focus();
        //console.info('focus end');
        return;
    }
    setTimeout(() => {
        element.focus();
        //console.info('focus end (delayed)', delay);
    }, delay);
}
