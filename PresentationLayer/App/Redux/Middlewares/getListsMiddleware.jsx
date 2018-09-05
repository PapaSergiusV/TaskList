export default store => next => action => {
    console.log("middleware");
    next(action);
}