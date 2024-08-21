using MarketMAUI.Models;
using MarketMAUI.Service;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;

namespace MarketMAUI.Pages;

public partial class RegistrPage : ContentPage
{
	User contextUser;
	public RegistrPage(Models.User user)
	{
		InitializeComponent();
		contextUser = user;
		Content.BindingContext = contextUser;
	}

    private async void BSignUp_Clicked(object sender, EventArgs e)
    {
		await DataManager.Init();
		var error = ValidationLine.Validation(contextUser);
		if (error.Length == 0)
		{
			if (contextUser.Login.Contains("@"))
			{
                if (DataManager.users.FirstOrDefault(x => x.Login == contextUser.Login) == null)
                {
                    contextUser.Password = HashToMD5.GetMD5(contextUser.Password);
                    var response = await NetManager.Post("api/Users", contextUser);

                    await SendMsg(contextUser);

                    //Запоминание User в кэш
                    var jsonData = JsonConvert.SerializeObject(contextUser);
                    DataManager.InitDataFile(Path.Combine(FileSystem.Current.AppDataDirectory, "casheUser.json"), jsonData);

                    await Navigation.PushAsync(new AppShell());
                }
                else
                {
					await DisplayAlert("Error", "You are already registred", "OK");             
                }
			}
			else
			{
				await DisplayAlert("Error", "Incorrect login","Input again");
                
            }
									
		}
		else
		{
			await DisplayAlert("Error", error.ToString(), "Input again");
			
		}
    }

    private async Task SendMsg(User contextUser)
    {
		string fromEmail = "mardanovajdar79@gmail.com";
        var from = new MailAddress(fromEmail,"Mobule App");
        var to = new MailAddress(contextUser.Login);
        var message = new MailMessage(from, to);
        message.Subject = "Thanks for joining us!";
        message.Body = $"<td align=\"center\" class=\"esd-stripe\">\r\n  <table bgcolor=\"#ffffff\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" class=\"es-content-body\">\r\n    <tbody>\r\n      <tr>\r\n        <td align=\"left\" class=\"esd-structure es-p15t es-p20r es-p20l\">\r\n          <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n            <tbody>\r\n              <tr>\r\n                <td width=\"560\" align=\"center\" valign=\"top\" class=\"esd-container-frame\">\r\n                  <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                    <tbody>\r\n                      <tr>\r\n                        <td align=\"center\" class=\"esd-block-image es-p10t es-p10b\" style=\"font-size:0px\">\r\n                          <a target=\"_blank\">\r\n                            <img src=\"https://eopmqbk.stripocdn.email/content/guids/CABINET_f3fc38cf551f5b08f70308b6252772b8/images/96671618383886503.png\" alt=\"\" width=\"100\" style=\"display:block\">\r\n                          </a>\r\n                        </td>\r\n                      </tr>\r\n                      <tr>\r\n                        <td align=\"center\" esd-links-underline=\"none\" class=\"esd-block-text es-p15t es-p15b es-m-txt-c\">\r\n                          <h1>\r\n                            Thanks for joining us!\r\n                          </h1>\r\n                        </td>\r\n                      </tr>\r\n                      <tr>\r\n                        <td align=\"left\" class=\"esd-block-text es-p10t es-p10b\">\r\n                          <p style=\"font-size:16px\">\r\n                            Hello, {contextUser.Name}! Thanks for joining us! You are now on our mailing list. This means you'll be the first&nbsp;to hear about our fresh&nbsp;collections and offers!\r\n                          </p>\r\n                        </td>\r\n                      </tr>\r\n                    </tbody>\r\n                  </table>\r\n                </td>\r\n              </tr>\r\n            </tbody>\r\n          </table>\r\n        </td>\r\n      </tr>\r\n      <tr>\r\n        <td align=\"left\" class=\"esd-structure esdev-adapt-off es-p20\">\r\n          <table width=\"560\" cellpadding=\"0\" cellspacing=\"0\" class=\"esdev-mso-table\">\r\n            <tbody>\r\n              <tr>\r\n                <td valign=\"top\" class=\"esdev-mso-td\">\r\n                  <table cellpadding=\"0\" cellspacing=\"0\" align=\"left\" class=\"es-left\">\r\n                    <tbody>\r\n                      <tr>\r\n                        <td width=\"146\" align=\"left\" class=\"esd-container-frame\">\r\n                          <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                            <tbody>\r\n                              <tr>\r\n                                <td align=\"center\" height=\"40\" class=\"esd-block-spacer\"></td>\r\n                              </tr>\r\n                            </tbody>\r\n                          </table>\r\n                        </td>\r\n                      </tr>\r\n                    </tbody>\r\n                  </table>\r\n                </td>\r\n                <td valign=\"top\" class=\"esdev-mso-td\">\r\n                  <table cellpadding=\"0\" cellspacing=\"0\" align=\"left\" class=\"es-left\">\r\n                    <tbody>\r\n                      <tr>\r\n                        <td width=\"121\" align=\"left\" class=\"esd-container-frame\">\r\n                          <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" bgcolor=\"#e8eafb\" style=\"background-color:#e8eafb;border-radius:10px 0 0 10px;border-collapse:separate\">\r\n                            <tbody>\r\n                              <tr>\r\n                                <td align=\"right\" class=\"esd-block-text es-p10t\">\r\n                                  <p>\r\n                                    Login:\r\n                                  </p>\r\n                                </td>\r\n                              </tr>\r\n                              <tr>\r\n                                <td align=\"right\" class=\"esd-block-text es-p10b\">\r\n                                  <p>\r\n                                    Password:\r\n                                  </p>\r\n                                </td>\r\n                              </tr>\r\n                            </tbody>\r\n                          </table>\r\n                        </td>\r\n                      </tr>\r\n                    </tbody>\r\n                  </table>\r\n                </td>\r\n                <td valign=\"top\" class=\"esdev-mso-td\">\r\n                  <table cellpadding=\"0\" cellspacing=\"0\" align=\"left\" class=\"es-left\">\r\n                    <tbody>\r\n                      <tr>\r\n                        <td width=\"155\" align=\"left\" class=\"esd-container-frame\">\r\n                          <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" bgcolor=\"#e8eafb\" style=\"background-color:#e8eafb;border-radius:0 10px 10px 0;border-collapse:separate\">\r\n                            <tbody>\r\n                              <tr>\r\n                                <td align=\"left\" class=\"esd-block-text es-p10t es-p10l\">\r\n                                  <p>\r\n                                    <strong>\r\n                                      {contextUser.Login}\r\n                                    </strong>\r\n                                  </p>\r\n                                </td>\r\n                              </tr>\r\n                              <tr>\r\n                                <td align=\"left\" class=\"esd-block-text es-p10b es-p10l\">\r\n                                  <p>\r\n                                    <strong>\r\n                                      {contextUser.Password}\r\n                                    </strong>\r\n                                  </p>\r\n                                </td>\r\n                              </tr>\r\n                            </tbody>\r\n                          </table>\r\n                        </td>\r\n                      </tr>\r\n                    </tbody>\r\n                  </table>\r\n                </td>\r\n                <td valign=\"top\" class=\"esdev-mso-td\">\r\n                  <table cellpadding=\"0\" cellspacing=\"0\" align=\"right\" class=\"es-right\">\r\n                    <tbody>\r\n                      <tr>\r\n                        <td width=\"138\" align=\"left\" class=\"esd-container-frame\">\r\n                          <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n                            <tbody>\r\n                              <tr>\r\n                                <td align=\"center\" height=\"40\" class=\"esd-block-spacer\"></td>\r\n                              </tr>\r\n                            </tbody>\r\n                          </table>\r\n                        </td>\r\n                      </tr>\r\n                    </tbody>\r\n                  </table>\r\n                </td>\r\n              </tr>\r\n            </tbody>\r\n          </table>\r\n        </td>\r\n      </tr>\r\n      <tr>\r\n        <td align=\"left\" class=\"esd-structure es-p10b es-p20r es-p20l\">\r\n          <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n            <tbody>\r\n              <tr>\r\n                <td width=\"560\" align=\"center\" valign=\"top\" class=\"esd-container-frame\">\r\n                  <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-radius:5px;border-collapse:separate\">\r\n                    <tbody>\r\n                      <tr>\r\n                      </tr>\r\n                      <tr>\r\n                      </tr>\r\n                    </tbody>\r\n                  </table>\r\n                </td>\r\n              </tr>\r\n            </tbody>\r\n          </table>\r\n        </td>\r\n      </tr>\r\n    </tbody>\r\n  </table>\r\n</td>";
        message.IsBodyHtml = true;
        var smpt = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential
            {
                UserName = fromEmail,
                Password = "bmsnylvdheacnkoz"
            },

            EnableSsl = true

        };

        await smpt.SendMailAsync(message);
        
    }
}