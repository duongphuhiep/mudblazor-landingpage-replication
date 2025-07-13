/**
 * add support for DebounceInputEvent on client side
 * @param {HTMLInputElement} inputElement
 * @param {number} delay
 */
export function supportDebounceInputEvent(inputElement, delay = 500) {
    if (!inputElement) {
        throw new Error('null argument');
    }
    if (!(inputElement instanceof HTMLInputElement)) {
        throw new Error('invalid argument, not a HTMLInputElement');
    }

    if (inputElement.debounceEventSupported) {
        console.warn('inputElement has already support debounceInput');
        return;
    }

    inputElement.bounceValue = inputElement.value;
    if (inputElement.value) {
        dispatchDebounceInputEvent(null)
    }

    // Add the input event listener that handles debouncing
    inputElement.addEventListener('input', function (e) {
        // Clear the previous timer
        if (inputElement.debounceTimer) {
            clearTimeout(inputElement.debounceTimer);
        }
        // Set a new timer
        dispatchDebounceInputEvent(e);
    });
    inputElement.debounceEventSupported = true;
    console.info('inputElement support debounceInput now');

    function dispatchDebounceInputEvent(e) {
        inputElement.debounceTimer = setTimeout(() => {
            const newBounceValue = inputElement.value;
            if (getBounceValue(inputElement) === newBounceValue) {
                //bouceValue not changed. skip dispatch event;
                return;
            }
            // Create and dispatch the custom debounceInput event
            const debounceEvent = new CustomEvent('debounceinput', {
                detail: {
                    originalEvent: e,
                    value: newBounceValue,
                },
                bubbles: true,
                cancelable: true,
            });
            setBounceValue(inputElement, newBounceValue);
            inputElement.dispatchEvent(debounceEvent);
        }, delay);
    }
}

export function getBounceValue(inputElement) {
    return inputElement.bounceValue;
}

export function setBounceValue(inputElement, value) {
    inputElement.bounceValue = value;
    if (inputElement.value !== value) {
        inputElement.value = value;
    }
}

export function focus(element) {
    console.log('focus', element);
    element.focus();
}