export default (lists = { key: "", value: [] }, action) => {

    const { type } = action;

    switch (type) {
        case 'GET_LISTS': return { key: "xxx", value: [] };
    }

    return lists;
}