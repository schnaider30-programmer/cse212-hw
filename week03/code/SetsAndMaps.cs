using System.Runtime.InteropServices;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        HashSet<string> wordsSet = new();
        List<string> pairs = new List<string>(words.Length); 
        for(int i = 0; i < words.Length; i++)
        {
            wordsSet.Add(words[i]);
            string reversedWord = ReverseWord(words[i]);
            if (wordsSet.Contains(reversedWord) && words[i] != reversedWord)
            {
                string pair = $"{words[i]} & {reversedWord}";
                pairs.Add(pair);
            }
        }

        ;
        return pairs.ToArray();
    }

    static string ReverseWord(string word)
    {
        char[] wordChars = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            wordChars[i] = word[word.Length - 1 - i];
        }
        
        return new string(wordChars);
    }


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            string degree = fields[3];
            int sum = 1;
            if (!degrees.ContainsKey(degree))
            {
                degrees[degree] = sum;
            }
            else
            {
                
                degrees[degree] += 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = CleanText(word1); 
        string clean2 = CleanText(word2);

        if (clean1.Length != clean2.Length)
        {
            return false;
        }

        Dictionary<char, int> letters = new();

        for (int i = 0; i < clean1.Length; i++)
        {
            if (!letters.ContainsKey(clean1[i]))
            {
                letters[clean1[i]] = 1;
            }
            else if (letters.ContainsKey(clean1[i]))
            {
                letters[clean1[i]] += 1;
            }
        }
        
        foreach(char letter in clean2)
        {
            if (!letters.ContainsKey(letter))
                return false;

            letters[letter] -= 1;

            if(letters[letter] < 0)
            {
                return false;
            }
        }
        
        return true;
    }

    private static string CleanText(string text)
    {
        char[] letters = new char[text.Length];
        int index = 0;

        foreach (char let in text)
        {
            if (let != ' ')
            {
                letters[index] = char.ToLower(let);
                index++;
            }
        }
        
        return new string(letters, 0, index);
    }


    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };



        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        int length = featureCollection.Features.Count;
        string[] summary = new string[length];
        int index = 0;
        foreach (Feature feature in featureCollection.Features)
        {
            Properties properties = feature.Properties;
            string Place = properties.Place;
            double? Mag = properties.Mag;
            summary[index] = $"{Place} - Mag {Mag}";
            index++;
        }

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return summary;
    }
}