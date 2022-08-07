export const httpGet = <T>(url: string): Promise<T> => {
    const headers: Headers = generateHeaders();
    return fetch(
        `/api/${url}`, {
        method: 'GET',
        headers
    }).then(handleResponse);
}

export const httpPost = <T>(url: string, body: string | undefined): Promise<T> => {
    const headers: Headers = generateHeaders();
    return fetch(`/api/${url}`, {
        method: 'POST',
        headers,
        body
    }).then(handleResponse);
}

export const httpPut = <T>(url: string, body: string | undefined): Promise<T> => {
    const headers: Headers = generateHeaders();
    return fetch(`/api/${url}`, {
        method: 'PUT',
        headers,
        body
    }).then(handleResponse);
}

export const httpDelete = <T>(url: string, accessToken: string): Promise<T> => {
    const headers: Headers = generateHeaders();
    return fetch(`/api/${url}`, {
        method: 'DELETE',
        headers
    }).then(handleResponse);
}

const generateHeaders = (): Headers => {
    const headers: Headers = new Headers();

    headers.append('Accept', 'application/json; text/javascript, */*');
    headers.append('Content-Type', 'application/json; charset=UTF-8');

    return headers;
}

const handleResponse = async (response: Response) => {
    
    return response.text().then((text: string) => {
        let data: any = null;
        let textData = null;
        try {
            data = text && JSON.parse(text);
        } catch (ex) {
            textData = text;
        }

        if (!response.ok) {
            let responseText = response.statusText;

            let error = '';

            if (data) {
                let serverErrors: string = '';
                Object.keys(data).forEach(key => {
                    serverErrors += `${data[key]}`;
                });
                error = serverErrors;
            } else if (textData) {
                error = textData;
            } else {
                error = responseText;
            }

            return Promise.reject(response.status + ' ' + error);
        }

        return data;
    });
};