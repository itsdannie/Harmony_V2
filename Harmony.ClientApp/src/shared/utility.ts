export function css(...items: Array<string | undefined>): string {
    return (items || []).filter(x => !!x).join(' ');
}

export const nameof = <T>(key: keyof T): string => key as string;