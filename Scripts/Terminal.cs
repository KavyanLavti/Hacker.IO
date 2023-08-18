using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Search;
using System.Net.NetworkInformation;
using Unity.VisualScripting;

public class Terminal : MonoBehaviour
{
    public TMP_InputField TerminalInput;
    public TextMeshProUGUI TerminalOutput;
    public string IP_CommandLine;
    TouchScreenKeyboard Keyboard = new TouchScreenKeyboard("",TouchScreenKeyboardType.Default,true,false,true,true,"",0);

    [Header("Initialise")]
    public float typingSpeed;
    public int i;
    [TextArea(2, 12)]
    public string Initialise_process;

    [Header("Connect")]
    [TextArea(2, 4)]
    public string ConnectionLines;

    [Header("map")]
    public GameObject Map_panel;

    [Header("BGND")]
    public GameObject BNGCanvas;
    BG_apps_open bG_Apps_Open;
    Event_handler_for_game event_Handler_For_Game;
    Open_terminal open_Terminal;
    
    [Header("mobile")]
    public Mobile_prefab_scriptable_object mobile_for_terminal;

    [Header("command_media_search")]
    public Insta_scriptable_object[] three_letter_name;
    public Insta_scriptable_object[] four_letter_name;
    public Insta_scriptable_object[] five_letter_name;
    public Insta_scriptable_object[] six_letter_name;
    public Insta_scriptable_object[] seven_letter_name;
    public Insta_scriptable_object[] eight_letter_name_;
    public Insta_scriptable_object[] nine_letter_name;
    public Insta_scriptable_object[] ten_letter_name;

    [Header("Media panel")]
    public GameObject media_panel;
    Media_controller media_controller;

    [Header("Storage_copy")]
    public GameObject DocumentPanel;
    public GameObject ImagePanel;
    public GameObject VideosPanel;
    public GameObject LogPanel;
    Document_controls document_Controls;
    Image_Control image_Control;
    Video_controller video_Controller;
    Logs_controller logs_controller;

    [Header("cloud_storage")]
    public GameObject cloud_storage;
    Cloud_storage_controller cloud_storage_controller;

    [Header("isConnected")]
    public bool isConnected;
    public string IsConnectedString;

    [Header("proxySolver")]
    public int numberOfShellRunning;
    public string proxyBreakString;
    public float proxytypingSpeed;

    [Header("firewall_solutions")]
    int NoofTimesfirewayanalysed;
    public string firewallSolvedString;

    [Header("PortHack")]
    public string PorthackingString;
    public float PortHackingProcessSpeed;

    [Header("IPv6Hack")]
    public string IPv6Hackstring;
    public int Ipv6HackingSpeed;

    //[Header("check")]
    //public string Checkerstring;
    private void Start()
    {
        i = 0;
        NoofTimesfirewayanalysed = 0;
        numberOfShellRunning = 0;
        isConnected = false;
        Keyboard.active = false;
        Map_panel.SetActive(false);
        bG_Apps_Open = BNGCanvas.GetComponent<BG_apps_open>();
        open_Terminal = BNGCanvas.GetComponent<Open_terminal>();
        event_Handler_For_Game = BNGCanvas.GetComponent<Event_handler_for_game>();
        media_controller = media_panel.GetComponent<Media_controller>();
        document_Controls = DocumentPanel.GetComponent<Document_controls>();
        image_Control = ImagePanel.GetComponent<Image_Control>();
        video_Controller = VideosPanel.GetComponent<Video_controller>();
        cloud_storage_controller = cloud_storage.GetComponent<Cloud_storage_controller>();
        logs_controller = LogPanel.GetComponent<Logs_controller>();
    }
    public void HandleInput(TMP_InputField terminalInput)
    {
        string InputText = terminalInput.text;
        if(InputText == null) 
        { 
            TerminalOutput.text += IP_CommandLine+"\n"; 
        }
        else if (InputText != null)
        {
            string[] Splitted_command = InputText.Split(" ");
            TerminalOutput.text += IP_CommandLine + ": " + InputText + "\n";
            if (Splitted_command[0] == "netsrch")
            {
                if (Splitted_command[2] == null)
                {
                    if (Splitted_command[1].Length == 3)
                    {
                        for (int i = 0; i < three_letter_name.Length; i++)
                        {
                            if (three_letter_name[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = three_letter_name[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 4)
                    {
                        for (int i = 0; i < four_letter_name.Length; i++)
                        {
                            if (four_letter_name[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = four_letter_name[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 5)
                    {
                        for (int i = 0; i < five_letter_name.Length; i++)
                        {
                            if (five_letter_name[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = five_letter_name[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 6)
                    {
                        for (int i = 0; i < six_letter_name.Length; i++)
                        {
                            if (six_letter_name[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = six_letter_name[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 7)
                    {
                        for (int i = 0; i < seven_letter_name.Length; i++)
                        {
                            if (seven_letter_name[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = seven_letter_name[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 8)
                    {
                        for (int i = 0; i < eight_letter_name_.Length; i++)
                        {
                            if (eight_letter_name_[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = eight_letter_name_[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 9)
                    {
                        for (int i = 0; i < nine_letter_name.Length; i++)
                        {
                            if (nine_letter_name[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = nine_letter_name[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 10)
                    {
                        for (int i = 0; i < ten_letter_name.Length; i++)
                        {
                            if (ten_letter_name[i].name == Splitted_command[1])
                            {
                                media_controller.Media_store = ten_letter_name[i];
                                media_panel.SetActive(true);
                                media_controller.InstaPageVisit();
                                break;
                            }
                        }
                    }
                    else
                    {
                        //show error
                    }
                }
                else if (Splitted_command[2] == "altnames")
                {
                    TerminalOutput.text += IP_CommandLine + "\n";
                    if (Splitted_command[1].Length == 3)
                    {
                        for (int i = 0; i < three_letter_name.Length; i++)
                        {
                            if (three_letter_name[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < three_letter_name[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += three_letter_name[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 4)
                    {
                        for (int i = 0; i < four_letter_name.Length; i++)
                        {
                            if (four_letter_name[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < four_letter_name[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += four_letter_name[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 5)
                    {
                        for (int i = 0; i < five_letter_name.Length; i++)
                        {
                            if (five_letter_name[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < five_letter_name[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += five_letter_name[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 6)
                    {
                        for (int i = 0; i < six_letter_name.Length; i++)
                        {
                            if (six_letter_name[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < six_letter_name[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += six_letter_name[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 7)
                    {
                        for (int i = 0; i < seven_letter_name.Length; i++)
                        {
                            if (seven_letter_name[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < seven_letter_name[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += seven_letter_name[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 8)
                    {
                        for (int i = 0; i < eight_letter_name_.Length; i++)
                        {
                            if (eight_letter_name_[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < eight_letter_name_[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += eight_letter_name_[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 9)
                    {
                        for (int i = 0; i < nine_letter_name.Length; i++)
                        {
                            if (nine_letter_name[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < nine_letter_name[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += nine_letter_name[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else if (Splitted_command[1].Length == 10)
                    {
                        for (int i = 0; i < ten_letter_name.Length; i++)
                        {
                            if (ten_letter_name[i].name == Splitted_command[1])
                            {
                                for (int i2 = 0; i2 < ten_letter_name[i].alternate_names.Length; i2++)
                                {
                                    TerminalOutput.text += ten_letter_name[i].alternate_names[i2] + "\n";
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        //Show error message in red
                        //person not identified error in textbox
                    }
                }
            }
            else if (Splitted_command[0] == "cmt")
            {
                if (Splitted_command[1] == " doc")
                {
                    for (int i = 0; i < mobile_for_terminal.pDF_Scriptable_Objects.Length; i++)
                    {
                        if (Splitted_command[2] == mobile_for_terminal.pDF_Scriptable_Objects[i].name)
                        {
                            document_Controls.AddDocument(mobile_for_terminal.pDF_Scriptable_Objects[i]);
                            break;
                        }
                        //else TerminalOutput.text += "ERROR 404 NOT FOUND" + "\n";
                    }
                }
                else if (Splitted_command[1] == "img")
                {
                    for (int i = 0; i < mobile_for_terminal.image_Scriptable_Objects.Length; i++)
                    {
                        if (Splitted_command[2] == mobile_for_terminal.image_Scriptable_Objects[i].name)
                        {
                            image_Control.AddImage(mobile_for_terminal.image_Scriptable_Objects[i]);
                            break;
                        }
                        //else TerminalOutput.text += "ERROR 404 NOT FOUND" + "\n";
                    }
                }
                else if ((Splitted_command[1]) == "vid")
                {
                    for (int i = 0; i < mobile_for_terminal.video_Scriptable_Objects.Length; i++)
                    {
                        if (Splitted_command[2] == mobile_for_terminal.video_Scriptable_Objects[i].name)
                        {
                            video_Controller.AddVideo(mobile_for_terminal.video_Scriptable_Objects[i]);
                            break;
                        }
                    }
                }
                else if (Splitted_command[1] == "bin")
                {
                    for (int i = 0; i < mobile_for_terminal.logs_Scriptales.Length; i++)
                    {
                        if (Splitted_command[2] == mobile_for_terminal.logs_Scriptales[i].name)
                        {
                            logs_controller.AddLog(mobile_for_terminal.logs_Scriptales[i]);
                            break;
                        }
                        //else TerminalOutput.text += "ERROR 404 NOT FOUND" + "\n";
                    }
                }
                else
                {
                    TerminalOutput.text += "ERROR 404 NOT FOUND" + "\n";
                }
            }
            else if (Splitted_command[0] == "rm")
            {
                if (Splitted_command[1] == "doc")
                {
                    for (int i = 0; i < cloud_storage_controller.Document_StorageTransform.childCount; i++)
                    {
                        Transform transform = cloud_storage_controller.Document_StorageTransform.GetChild(i);
                        if (transform.gameObject.GetComponent<DocumentNumber>().Dname == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
                else if (Splitted_command[1] == "img")
                {
                    for (int i = 0; i < cloud_storage_controller.Image_StorageTransform.childCount; i++)
                    {
                        Transform transform = cloud_storage_controller.Image_StorageTransform.GetChild(i);
                        if (transform.gameObject.GetComponent<Image_number>().Iname == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
                else if (Splitted_command[1] == "vid")
                {
                    for (int i = 0; i < cloud_storage_controller.Videos_StorageTransform.childCount; i++)
                    {
                        Transform transform = cloud_storage_controller.Videos_StorageTransform.GetChild(i);
                        if (transform.gameObject.GetComponent<Video_storage_per_button>().Vname == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
                else if (Splitted_command[1] == "bin")
                {
                    for (int i = 0; i < cloud_storage_controller.Bin_StorageTransform.childCount; i++)
                    {
                        Transform transform = cloud_storage_controller.Bin_StorageTransform.GetChild(i);
                        if (transform.gameObject.GetComponent<Button_script_logs>().LogName == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
                else
                {
                    TerminalOutput.text += "ERROR 404 NOT FOUND\n";
                }
            }
            else if (Splitted_command[0] == "rm/")
            {
                if (Splitted_command[1] == "doc")
                {
                    for (int i = 0; i < document_Controls.Parent_panel_transform.childCount; i++)
                    {
                        Transform transform = document_Controls.Parent_panel_transform.GetChild(i);
                        if (transform.gameObject.GetComponent<DocumentNumber>().Dname == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
                else if (Splitted_command[1] == "img")
                {
                    for (int i = 0; i < image_Control.Parent_panel_transform.childCount; i++)
                    {
                        Transform transform = image_Control.Parent_panel_transform.GetChild(i);
                        if (transform.gameObject.GetComponent<Image_number>().Iname == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
                else if (Splitted_command[1] == "vid")
                {
                    for (int i = 0; i < video_Controller.parent_panel_transform.childCount; i++)
                    {
                        Transform transform = video_Controller.parent_panel_transform.GetChild(i);
                        if (transform.gameObject.GetComponent<Video_storage_per_button>().Vname == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
                else if (Splitted_command[1] == "bin")
                {
                    for (int i = 0; i < logs_controller.Parent_panel_transform.childCount; i++)
                    {
                        Transform transform = logs_controller.Parent_panel_transform.GetChild(i);
                        if (transform.gameObject.GetComponent<Button_script_logs>().LogName == Splitted_command[2])
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
            }
            else if (Splitted_command[0] == "fuck")
            {
                TerminalOutput.text += "damn you pervert, play the game\n";
            }
            else if (Splitted_command[0] == "probe" && Splitted_command.Length==1)
            {
                if(isConnected)
                {
                    TerminalOutput.text += "--------------\n";
                    TerminalOutput.text += "--------------\n";
                    for (int m=0; m<mobile_for_terminal.ports.Length; m++)
                    {
                        TerminalOutput.text += mobile_for_terminal.ports[m].portType + ' ' + mobile_for_terminal.ports[m].adress + ' ';
                        if (mobile_for_terminal.ports[m].isLocked)
                        {
                            TerminalOutput.text += "Locked\n";
                        }
                        else
                        {
                            TerminalOutput.text += '\n';
                        }
                    }
                    TerminalOutput.text += "--------------\n";
                    TerminalOutput.text += "Number of ports needed to access the device: " + mobile_for_terminal.No_of_ports_needed_to_unlock.ToString() +'\n';
                    if (mobile_for_terminal.haveProxy)
                    {
                        TerminalOutput.text += "proxy detected\n";
                    }
                    if (mobile_for_terminal.haveFirewall)
                    {
                        TerminalOutput.text += "Firewall detected\n";
                    }
                    TerminalOutput.text += "--------------\n";
                }
                else
                {
                    TerminalOutput.text += "Not connected to any device";
                }
            }
            else if (Splitted_command[0] == "shell")
            {
                if (Splitted_command.Length == 1)
                {
                    if (!isConnected)
                    {
                        TerminalOutput.text = "running shell number" + (numberOfShellRunning+1).ToString();
                        numberOfShellRunning++;
                    }
                    else
                    {
                        TerminalOutput.text += "does not have administrative access\n";
                    }
                }
                else if(isConnected)
                {
                    if (Splitted_command[1] == "ovld")
                    {
                        if(numberOfShellRunning >= mobile_for_terminal.proxyLevel)
                        {
                            StartCoroutine(proxybreaking());
                            mobile_for_terminal.haveProxy = false;
                        }
                        else
                        {
                            TerminalOutput.text += "not enough shells to overload";
                        }
                    }
                    else
                    {
                        TerminalOutput.text += "No command present : Incorrect Syntax\n";
                    }
                }
            }
            else if (Splitted_command[0] == "analyze" && Splitted_command.Length==1)
            {
                if(isConnected)
                {
                    if(mobile_for_terminal.haveFirewall)
                    {
                        if (mobile_for_terminal.FirewallType == 1 && NoofTimesfirewayanalysed < mobile_for_terminal.Fire1wall_codes.Length)
                        {
                            TerminalOutput.text += mobile_for_terminal.Fire1wall_codes[NoofTimesfirewayanalysed];
                            NoofTimesfirewayanalysed++;
                        }
                        else TerminalOutput.text += "____________________________\nFirewall analyzed to simplest form";
                    }
                    else
                    {
                        TerminalOutput.text += " __________________\nNo firewall present\n __________________\n";
                    }
                }
                else
                {
                    TerminalOutput.text += " __________________\nNot connected to any device\n";
                }
            }
            else if (Splitted_command[0] == "solve")
            {
                if(isConnected)
                {
                    if (mobile_for_terminal.haveFirewall)
                    {
                        if(mobile_for_terminal.FirewallType == 1)
                        {
                            if (Splitted_command[1] == mobile_for_terminal.Fire1wall_codes_solution && Splitted_command.Length==2)
                            {
                                StartCoroutine(SolvingFirewall_one());
                                mobile_for_terminal.haveFirewall = false;
                            }
                            else
                            {
                                TerminalOutput.text += "Firewall key does not match\n";
                            }
                        }
                        else if(mobile_for_terminal.FirewallType == 2)
                        {
                            
                        }
                    }
                    else
                    {
                        TerminalOutput.text += "No firewall detected\n";
                    }
                }
                else
                {
                    TerminalOutput.text += "Not connected to any device\n";
                }
            }
            else if (Splitted_command[0] == "porthack" && Splitted_command.Length == 1)
            {
                if (isConnected)
                {
                   if(mobile_for_terminal.No_of_ports_unlocked >= mobile_for_terminal.No_of_ports_needed_to_unlock)
                   {
                        StartCoroutine(Porthackingporcess());
                        for (int y = 0; y < mobile_for_terminal.ports.Length; y++)
                        {
                            mobile_for_terminal.ports[y].isLocked = false;
                        }
                        mobile_for_terminal.No_of_ports_unlocked = mobile_for_terminal.No_of_ports_total;
                        cloud_storage_controller.IsConnected = true;
                   }
                   else
                   {
                        TerminalOutput.text += "Not enough open ports to carry out PORTHACK\n";
                   }
                }
                else TerminalOutput.text += "Not connected to any device\n";
            }
            else if (Splitted_command[0] == "ipv6crack" && Splitted_command.Length==2)
            {
                if (isConnected)
                {
                    if(!mobile_for_terminal.haveFirewall)
                    {
                        if(!mobile_for_terminal.haveProxy) 
                        {
                            for (int u = 0; u < mobile_for_terminal.ports.Length; u++)
                            {
                                if (mobile_for_terminal.ports[u].portType == Ports.PortType.IPv6 && mobile_for_terminal.ports[u].adress == Splitted_command[1])
                                {
                                    if (mobile_for_terminal.ports[u].isLocked)
                                    {
                                        mobile_for_terminal.ports[u].isLocked = false;
                                        mobile_for_terminal.No_of_ports_unlocked++;
                                    }
                                    StartCoroutine(IPv6Hack());
                                }
                            }
                        }
                        else
                        {
                            TerminalOutput.text += "---------------------\nDevice is Protected by Proxy\n";
                        }
                    }
                    else
                    {
                        TerminalOutput.text += "---------------------\nDevice has an unsolved firewall\n";
                    }
                }
                else TerminalOutput.text += "Not connected to any device\n";
            }
            else if (Splitted_command[0] == "clear" && Splitted_command.Length==1)
            {
                TerminalOutput.text = "";
            }
            


            //for both anayze and solve implement the different minigames;;;;;;;;

        }
        terminalInput.text = "";
    }
    public void OpenKeyboard()
    {
        Keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true);

    }
    public void closeKeyboard()
    {
        Keyboard.active = false;
        Keyboard = null;
    }
    public IEnumerator initialise(int i) 
    {
        if(i<1)
        {
            TerminalOutput.text += IP_CommandLine;
            string[] lines = Initialise_process.Split("\n");
            for (int j = 0; j < lines.Length; j++)
            {
                TerminalOutput.text += lines[j] + "\n";
                yield return new WaitForSeconds(typingSpeed);
            }
            TerminalOutput.text += "\n" + IP_CommandLine +"\n";
        }
    }
    public IEnumerator ConnectTodevice()
    {
        string[] lines = ConnectionLines.Split("\n");
        for(int i=0; i<lines.Length; i++)
        {
            TerminalOutput.text += lines[i] + "\n";
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public IEnumerator proxybreaking() 
    {
        string[] lines = proxyBreakString.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            TerminalOutput.text += lines[i] + "\n";
            yield return new WaitForSeconds(proxytypingSpeed);
        }
    }
    public IEnumerator SolvingFirewall_one() 
    {
        foreach (char c in firewallSolvedString)
        {
            TerminalOutput.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void OpenMap()
    {
        Map_panel.SetActive(true);
        event_Handler_For_Game.spawnButton();
    }
    public void BackButtonTerminal()
    {
        i++;
        {
            if (Map_panel.activeInHierarchy)
            {
                Map_panel.SetActive(false);
            }
            else
            {
                bG_Apps_Open.terminalclose();
                open_Terminal.i = 0;
            }
        }
    }
    public void BackButton_media()
    {
        media_controller.BackButton_media();
        media_panel.SetActive(false);
    }
    public IEnumerator Porthackingporcess()
    {
        foreach(char c in PorthackingString)
        {
            TerminalOutput.text += c;
            yield return new WaitForSeconds(PortHackingProcessSpeed);
        }
    }
    public IEnumerator IPv6Hack()
    {
        foreach (char c in IPv6Hackstring)
        {
            TerminalOutput.text += c;
            yield return new WaitForSeconds(Ipv6HackingSpeed);
        }
    }
}
