const setDelay: number = 300;

export const useDebounce = (func: (...args: string[]) => void) => {
  let timeoutId: NodeJS.Timeout;
  return (...args: string[]): void => {
    if (timeoutId) {
      clearTimeout(timeoutId);
    }
    timeoutId = setTimeout(() => {
      func(...args);
    }, setDelay);
  };
};
